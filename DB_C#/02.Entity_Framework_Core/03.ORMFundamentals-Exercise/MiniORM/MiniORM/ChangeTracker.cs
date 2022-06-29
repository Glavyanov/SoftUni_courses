using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	internal class ChangeTracker<TEntity>
        where TEntity : class, new() 
    {

        private readonly List<TEntity> allEntities;

        private readonly List<TEntity> added;

        private readonly List<TEntity> removed;

        public ChangeTracker(IEnumerable<TEntity> entities)
        {
            this.added = new List<TEntity>();
            this.removed = new List<TEntity>();
            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<TEntity> AllEntities => (IReadOnlyCollection<TEntity>)this.allEntities;

        public IReadOnlyCollection<TEntity> Added => (IReadOnlyCollection<TEntity>)this.added;

        public IReadOnlyCollection<TEntity> Removed => (IReadOnlyCollection<TEntity>)this.removed;

        public void Add(TEntity item) => this.added.Add(item);

        public void Remove(TEntity item) => this.removed.Add(item);

        public IEnumerable<TEntity> GetModifiedEntities(DbSet<TEntity> dbSet)
        {
            var modifiedEntities = new List<TEntity>();

            PropertyInfo[] primaryKeys = typeof(TEntity).GetProperties()
                                                        .Where(pi => pi.HasAttribute<KeyAttribute>())
                                                        .ToArray();

            foreach (var proxyEntity in this.AllEntities)
            {
                IEnumerable<object> proxyEntityPKV = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();
                TEntity originalEntity =
                    dbSet.Entities.Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(proxyEntityPKV));

                bool isModified = IsModified(originalEntity, proxyEntity);
                if (isModified)
                {
                    modifiedEntities.Add(originalEntity);
                }
            }

            return modifiedEntities;
        }

        private static List<TEntity> CloneEntities(IEnumerable<TEntity> entities)
        {
            List<TEntity> clonedEntities = new List<TEntity>();

            PropertyInfo[] propertiesToClone = typeof(TEntity).GetProperties().Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType)).ToArray();

            foreach (var entity in entities)
            {
                TEntity clonedEntity = Activator.CreateInstance<TEntity>();
                foreach (PropertyInfo property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);

                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, TEntity entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));

        }

        private static bool IsModified(TEntity entity, TEntity proxyEntity)
        {
            var monitoredProperties = typeof(TEntity).GetProperties()
                                                     .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            var modifiedProperties =
                monitoredProperties.Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity))).ToArray();
            bool isModified = modifiedProperties.Any();

            return isModified;
        }
    }
}