using EasterRaces.Core.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
           
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}
