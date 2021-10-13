using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class CarSalesman
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, byte> engineInfo = new Dictionary<string, byte>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] assign = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string engineModel = assign[0];
                string enginePower = assign[1];
                if (!engineInfo.ContainsKey(engineModel))
                {
                    engineInfo.Add(engineModel,0);
                    Engine engine = new Engine(engineModel, enginePower);
                    if (assign.Length > 2)
                    {
                        string current = assign[2];
                        bool isNum = true;
                        for (int j = 0; j < current.Length; j++)
                        {
                            if (!char.IsDigit(current[j]))
                            {
                                isNum = false;
                            }
                        }
                        if (isNum)
                        {
                            engine.Displacement = current;
                            
                        }
                        else
                        {
                            engine.Efficiency = current;
                        }
                        
                    }
                    if (assign.Length > 3)
                    {
                        engine.Efficiency = assign[3];
                    }
                    engines.Add(engine);
                }
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] assign = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = assign[0];
                string carEngine = assign[1];
                Car car = new Car();
                foreach (var item in engines)
                {
                    if (item.Model == carEngine)
                    {
                        car = new Car(carModel, item);
                    }
                }
                if (assign.Length > 2)
                {
                    string current = assign[2];
                    bool isNum = true;
                    for (int j = 0; j < current.Length; j++)
                    {
                        if (!char.IsDigit(current[j]))
                        {
                            isNum = false;
                        }
                    }
                    if (isNum)
                    {
                        car.Weight = current;
                    }
                    else
                    {
                        car.Color = current;
                    }
                }
                if (assign.Length > 3)
                {
                    car.Color = assign[3];
                }
                cars.Add(car);
            }
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
    }
}
