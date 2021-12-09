using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;
        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();

        public void Add(IPlanet planet)
        {
            if (this.planets != null)
            {
                this.planets.Add(planet);
            }
        }
        public bool Remove(IPlanet planet)
        {
            return this.planets != null ? this.planets.Remove(planet) : false;
        }

        public IPlanet FindByName(string name)
        {
            return this.planets.FirstOrDefault(a => a.Name == name);
        }
    }
}
