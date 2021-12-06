using System.IO;
using System;
using OnlineShop.Core;
using OnlineShop.IO;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models.Products.Computers;

namespace OnlineShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            /*var dict = new Dictionary<int, double>() { { 1, 2.5 }, { 2, 3.5 }, { 3, 4.5 } };
            double sum = dict.Select(c => c.Value).Average();
            Console.WriteLine(sum);*/
            IComponent centProcUnit = new CentralProcessingUnit(1, " Intel", "Xeon", 1600, 82, 9);
            IComponent motherBoard = new Motherboard(6, "Asus", "ROG", 1250, 70, 8);
            IPeripheral peripher = new Headset(3, "Razer", "Thresher", 300, 70, "AUX");
            IPeripheral keyboard = new Keyboard(4, "Microsoft", "First", 200, 70, "Bluetooth");
            var computer = new DesktopComputer(10, "Dell", "Unknown", 1200);
            Console.WriteLine($"Dell Performance: {computer.OverallPerformance}");
            computer.AddComponent(centProcUnit);
            computer.AddComponent(motherBoard);
            computer.AddPeripheral(peripher);
            computer.AddPeripheral(keyboard);
            double test = computer.OverallPerformance;
            Console.WriteLine(computer);
            //Console.WriteLine($"Comp price: {computer.Price}\nCompPerfor: {computer.OverallPerformance} ");
            return;
            // Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = null; //new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
