using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.RawData
{
    public class RawData
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] assign = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (assign.Length == 13)
                {
                    string model = assign[0];
                    Engine engine = new Engine(int.Parse(assign[1]), int.Parse(assign[2]));
                    Cargo cargo = new Cargo(int.Parse(assign[3]), assign[4]);
                    Tire[] tires = new Tire[4];
                    int count = 0;
                    for (int j = 5; j < assign.Length; j += 2)
                    {
                        Tire tire = new Tire(double.Parse(assign[j]), int.Parse(assign[j + 1]));
                        tires[count++] = tire;
                    }
                    Car car = new Car(model, engine, cargo, tires);
                    cars.Add(car);

                }
            }
            string command = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            if (command == "fragile")
            {
                foreach (var item in cars)
                {
                    if (item.Tires.Any(x => x.TirePressure < 1.0))
                    {
                        sb.AppendLine(item.Model);
                    }
                }

            }
            else if (command == "flammable") 
            {
                foreach (var item in cars)
                {
                    if (item.Engine.EnginePower > 250)
                    {
                        sb.AppendLine(item.Model);
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
