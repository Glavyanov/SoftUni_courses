using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.VehiclesExtension
{
    class VehiclesExtension
    {
        static void Main(string[] args)
        {
            string[] assignCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(assignCar[3]), double.Parse(assignCar[2]), double.Parse(assignCar[1]));
            string[] assignTruck = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(assignTruck[3]), double.Parse(assignTruck[2]), double.Parse(assignTruck[1]));
            string[] assignBus = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(assignBus[3]), double.Parse(assignBus[2]), double.Parse(assignBus[1]));
            List<Vehicle> vehicles = new List<Vehicle>() { car, truck, bus };

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Drive")
                {
                    Drive(command[1], vehicles, double.Parse(command[2]));

                }
                else if (command[0] == "DriveEmpty")
                {
                    if (command[1] == "Bus")
                    {
                        vehicles.Where(x => x.GetType().Name == command[1]).Cast<Bus>().Last().AirCondOn = false;
                        Drive(command[1], vehicles, double.Parse(command[2]));
                        vehicles.Where(x => x.GetType().Name == command[1]).Cast<Bus>().Last(x => x.AirCondOn = true);
                    }

                }
                else if (command[0] == "Refuel")
                {
                    try
                    {
                        Refuel(command[1], vehicles, double.Parse(command[2]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            vehicles.ForEach(Console.WriteLine);

        }

        private static void Refuel(string command, List<Vehicle> vehicles, double fuel)
        {
            vehicles.FirstOrDefault(x => x.GetType().Name == command).Refuel(fuel);

        }

        private static void Drive(string command, List<Vehicle> vehicles, double distance)
        {
            Console.WriteLine(vehicles.FirstOrDefault(x => x.GetType().Name == command).Drive(distance));
        }

    }
}
