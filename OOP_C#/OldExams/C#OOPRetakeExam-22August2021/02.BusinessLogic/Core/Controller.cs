using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;
        private int exploredPlanets;
        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);

            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);

            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            this.astronautRepository.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> collectionAstronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();
            if (collectionAstronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }
            var planet = this.planetRepository.Models.FirstOrDefault(p => p.Name == planetName);
            var mission = new Mission();
            mission.Explore(planet, collectionAstronauts);
            this.exploredPlanets++;
            var deadAstronauts = collectionAstronauts.Where(a => a.CanBreath == false).Count();

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: { string.Join(", ", astronaut.Bag.Items)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            this.astronautRepository.Remove(astronaut);
            return $"Astronaut {astronaut.Name} was retired!";
        }
    }
}
