using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> collection;

        protected Repository()
        {
            this.collection = new List<T>();
        }
        public void Add(T model) => this.collection.Add(model);

        public IReadOnlyCollection<T> GetAll() => this.collection;

        public virtual T GetByName(string name)
        {
            return this.collection.FirstOrDefault();
        }

        public bool Remove(T model) => this.collection.Remove(model);
    }
}
