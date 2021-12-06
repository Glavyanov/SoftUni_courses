using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            return this.collection.FirstOrDefault(c => c.Model == name);
        }
    }
}
