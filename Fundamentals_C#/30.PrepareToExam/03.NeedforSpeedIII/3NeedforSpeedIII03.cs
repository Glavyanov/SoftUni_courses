using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedforSpeedIII
{
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }


    }
    class NeedforSpeedIII
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //Audi A6|38000|62
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            for (int i = 0; i < n; i++)
            {
                string[] acceptCar = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string brand = acceptCar[0];
                int mileage = int.Parse(acceptCar[1]);
                int fuel = int.Parse(acceptCar[2]);
                Car car = new Car()
                {
                    Mileage = mileage,
                    Fuel = fuel
                };
                if (!cars.ContainsKey(brand))
                {
                    cars.Add(brand, car);
                }

            }
            //Drive : Audi A6 : 543 : 47
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] cmdArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string car = cmdArgs[1];
                if (action == "Drive")
                {
                    int kilometers = int.Parse(cmdArgs[2]);
                    int consumedFuel = int.Parse(cmdArgs[3]);
                    if (consumedFuel < cars[car].Fuel)
                    {
                        cars[car].Mileage += kilometers;
                        cars[car].Fuel -= consumedFuel;
                        Console.WriteLine($"{car} driven for {kilometers} kilometers. {consumedFuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    if (cars[car].Mileage > 100000 )
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");

                    }

                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    int current = cars[car].Fuel;
                    cars[car].Fuel += fuel;
                    if (cars[car].Fuel > 75)
                    {
                        cars[car].Fuel = 75;
                        Console.WriteLine($"{car} refueled with {cars[car].Fuel - current} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }

                }
                else if (action == "Revert")
                {
                    int kilometers = int.Parse(cmdArgs[2]);
                    cars[car].Mileage -= kilometers;
                    if (cars[car].Mileage < 10000)
                    {
                        cars[car].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }

                }

                command = Console.ReadLine();
            }
            foreach (var item in cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Mileage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }
        }
    }
}
