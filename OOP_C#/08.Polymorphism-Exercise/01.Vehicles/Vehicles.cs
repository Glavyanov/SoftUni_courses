using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Vehicles
{
    public class Vehicles
    {
        public static void Main(string[] args)
        {
            string[] assignCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(assignCar[1]), double.Parse(assignCar[2]));
            string[] assignTruck = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(assignTruck[1]), double.Parse(assignTruck[2]));
            List<Vehicle> vehicles = new List<Vehicle>() { car, truck};
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Drive")
                {
                    Drive(command[1], vehicles, double.Parse(command[2]));

                }
                else if (command[0] == "Refuel")
                {
                    Refuel(command[1], vehicles, double.Parse(command[2]));
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
