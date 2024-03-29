﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    //TODO : Finish with implementation of DbSet
	public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        public DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        internal IList<TEntity> Entities { get; set; }

        public int Count => this.Entities.Count();

        public bool IsReadOnly => this.Entities.IsReadOnly;

        public void Add(TEntity item)
        {
            _ = item ?? throw new ArgumentNullException(nameof(item), "Item cannot be null");
            this.Entities.Add(item);
            this.ChangeTracker.Add(item);
        }
        public bool Remove(TEntity item)
        {
            _= item?? throw new ArgumentNullException(nameof(item), "Item cannot be null");

            var removedSuccessfully = this.Entities.Remove(item);
            if(removedSuccessfully)
            {
                this.ChangeTracker.Remove(item);
            }
            return removedSuccessfully;
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                var currEntity = this.Entities.First();
                this.Entities.Remove(currEntity);
            }
        }

        public bool Contains(TEntity item) => this.Entities.Contains(item);

        public void CopyTo(TEntity[] array, int arrayIndex) => this.Entities.CopyTo(array, arrayIndex);

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToArray())
            {
                this.Remove(entity);
            }
        }

        public IEnumerator<TEntity> GetEnumerator() => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}