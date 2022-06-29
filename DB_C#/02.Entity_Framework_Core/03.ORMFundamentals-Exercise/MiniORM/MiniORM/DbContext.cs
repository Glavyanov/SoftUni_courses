using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Transactions;

namespace MiniORM
{
	public abstract class DbContext
    {
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);
            this.dbSetProperties = this.DiscoverDbSets();
            using var connectionManager = new ConnectionManager(this.connection);
            this.InitializeDbSets();
            this.MapAllRelations();
        }

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(double),
            typeof(bool),
            typeof(BigInteger),
            typeof(DateTime),
            typeof(TimeSpan),
            typeof(short),
            typeof(ushort),
            typeof(sbyte),
            typeof(byte),
            typeof(float)
        };

        public void SaveChanges()
        {
            var dbSets = this.dbSetProperties.Select(kvp => kvp.Value.GetValue(this)).ToArray();
            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet.Where(entity => !IsObjectValid(entity)).ToArray();
                _ = invalidEntities.Any() ? throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}") : false;
            }

            using var connectionManager = new ConnectionManager(this.connection);
            using var sqlTransaction = this.connection.StartTransaction();

            foreach (var dbSet in dbSets)
            {
                Type dbSetType = dbSet.GetType().GetGenericArguments().First();
                MethodInfo persistGenericMethod = typeof(DbContext).GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(dbSetType);
                try
                {
                    persistGenericMethod.Invoke(this, new object[] { dbSet });
                }
                catch (TargetInvocationException tie)
                {

                    throw tie.InnerException;
                }
                catch (InvalidOperationException)
                {
                    sqlTransaction.Rollback();
                    throw;
                }
                catch (SqlException)
                {
                    sqlTransaction.Rollback();
                    throw;
                }
            }
            sqlTransaction.Commit();
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tableName = GetTableName(typeof(TEntity));
            IEnumerable<string> columns = this.connection.FetchColumnNames(tableName);

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns.ToArray());
            }

            ICollection<TEntity> modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns.ToArray());
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns.ToArray());
            }
        }

        private void InitializeDbSets()
        {
            foreach (var dbSetKVP in this.dbSetProperties)
            {
                Type dbSetType = dbSetKVP.Key;
                PropertyInfo dbSetProperty = dbSetKVP.Value;

                MethodInfo populateDbSetMethodGeneric = typeof(DbContext).GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(dbSetType);
                populateDbSetMethodGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSetProperty)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> entities = LoadTableEntities<TEntity>();

            var dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, dbSetProperty.Name, dbSetInstance);
        }

        private void MapAllRelations()
        {
            foreach (var dbSetKVP in this.dbSetProperties)
            {
                Type dbSetType = dbSetKVP.Key;
                MethodInfo mapRelationsGeneric = typeof(DbContext).GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(dbSetType);

                var dbSet = dbSetKVP.Value.GetValue(this);
                mapRelationsGeneric.Invoke(this, new[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity: class,new()
        {
            Type entityType = typeof(TEntity);
            MapNavigationProperties(dbSet);

            PropertyInfo[] collections = entityType.GetProperties().Where(pi => pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)).ToArray();
            foreach (var collection in collections)
            {
                var collectionType = collection.PropertyType.GenericTypeArguments.First();
                var mapCollectionMethod = typeof(DbContext).GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(entityType, collectionType);

                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new() 
            where TCollection : class, new()
        {
            var entityType = typeof(TDbSet);
            var collectionType = typeof(TCollection);

            var primaryKeys = collectionType.GetProperties().Where(pi => pi.HasAttribute<KeyAttribute>()).ToArray();
            var primaryKey = primaryKeys.First();

            var foreignKey = entityType.GetProperties().First(pi => pi.HasAttribute<KeyAttribute>());

            var IsManyToMany = primaryKeys.Length >= 2;
            if (IsManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                    .First(pi => collectionType
                                    .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                                    .PropertyType == entityType);
            }

            var navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this);
            foreach (var entity in dbSet)
            {
                var primaryKeyValue = foreignKey.GetValue(entity);

                var navigationEntities = navigationDbSet.Where(ne => primaryKey.GetValue(ne).Equals(primaryKeyValue)).ToArray();

                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }


        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet) 
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);
            var foreignKeys = entityType.GetProperties().Where(pi => pi.HasAttribute<ForeignKeyAttribute>()).ToArray();


            foreach (var foreignKey in foreignKeys)
            {
                var navigationPropertyName = foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;
                var navigationProperty = entityType.GetProperty(navigationPropertyName);
                var navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType].GetValue(this);
                var navigationPrimaryKey = navigationProperty.PropertyType.GetProperties().First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    var foreignKeyValue = foreignKey.GetValue(entity);
                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet).First(cnp => navigationPrimaryKey.GetValue(cnp).Equals(foreignKeyValue));
                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }

            }
        }

        private string GetTableName(Type type)
        {
            var tableName = ((TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute)))?.Name;

            tableName ??= this.dbSetProperties[type].Name;
            return tableName;
        }

        private static bool IsObjectValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationErrors = new List<ValidationResult>();

            var validationResult =
                Validator.TryValidateObject(entity, validationContext, validationErrors, true);
            return validationResult;
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class, new()
        {
            var table = typeof(TEntity);
            string[] columns = GetEntityColumnNames(table).ToArray();
            var tableName = GetTableName(table);
            var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();
            return fetchedRows;
        }

        private string[] GetEntityColumnNames(Type table)
        {
            var tableName = this.GetTableName(table);
            var dbColumns = this.connection.FetchColumnNames(tableName);
            var columns = table.GetProperties()
                .Where(pi => dbColumns.Contains(pi.Name) && !pi.HasAttribute<NotMappedAttribute>() && AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();
            return columns;
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            var dbSets = this.GetType().GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);
            return dbSets;
        }
    }
}