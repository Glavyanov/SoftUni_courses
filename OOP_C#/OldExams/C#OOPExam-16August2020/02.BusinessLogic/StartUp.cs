using System.IO;
using System;
using OnlineShop.Core;
using OnlineShop.IO;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products;

namespace OnlineShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            // Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }

    }
}
