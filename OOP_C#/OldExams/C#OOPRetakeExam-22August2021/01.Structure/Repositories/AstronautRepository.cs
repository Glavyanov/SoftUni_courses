using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;
        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => this.astronauts.ToList().AsReadOnly();

        public void Add(IAstronaut astronaut)
        {
            if (this.astronauts != null)
            {
                this.astronauts.Add(astronaut);
            }
        }

        public bool Remove(IAstronaut astronaut)
        {
            return this.astronauts != null ? this.astronauts.Remove(astronaut) : false;
        }

        public IAstronaut FindByName(string name)
        {
            return this.astronauts.FirstOrDefault(a => a.Name == name);
        }
    }
}
