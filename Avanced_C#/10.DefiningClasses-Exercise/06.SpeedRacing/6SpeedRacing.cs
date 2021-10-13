using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> racingCars = new Dictionary<string, Car>();
            for (int i = 0; i < n; i++)
            {
                string[] assignCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = assignCar[0];
                if (!racingCars.ContainsKey(model))
                {
                    Car car = new Car(model, double.Parse(assignCar[1]), double.Parse(assignCar[2]));
                    racingCars.Add(model, car);

                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Drive")
                {
                    if (racingCars.ContainsKey(tokens[1]))
                    {
                        Car.Drive(racingCars[tokens[1]], double.Parse(tokens[2]));
                    }

                }

            }

            foreach (var item in racingCars)
            {
                Console.WriteLine($"{item.Key} {item.Value.FuelAmount:F2} {item.Value.TravelledDistance}");
            }
        }
    }
}
