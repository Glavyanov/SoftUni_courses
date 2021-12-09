using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.CanBreath)
                {
                    while (astronaut.CanBreath)
                    {
                        var item = planet.Items.FirstOrDefault();
                        if (item != null)
                        {
                            planet.Items.Remove(item);
                            astronaut.Breath();
                            astronaut.Bag.Items.Add(item);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
