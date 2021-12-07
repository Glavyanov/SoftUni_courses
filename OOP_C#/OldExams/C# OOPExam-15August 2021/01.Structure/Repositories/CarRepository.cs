using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;
        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => this.models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            this.models.Add(model); 
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(m => m.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
