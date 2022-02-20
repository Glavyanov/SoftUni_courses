using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Catalog
    {
        public List<Truck> Truck { get; set; }
        public List<Car> Car { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> catalogs = new List<Catalog>();
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputArr = input.Split('/', StringSplitOptions.RemoveEmptyEntries);
                string vehicle = inputArr[0];
                string brand = inputArr[1];
                string model = inputArr[2];
                int propt = int.Parse(inputArr[3]);
                if (vehicle == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = propt

                    };
                    cars.Add(car);

                }
                else if (vehicle == "Truck")
                {
                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = propt
                    };
                    trucks.Add(truck);

                }

                input = Console.ReadLine();
            }
            List<Car> allCars = cars.OrderBy(x => x.Brand).ToList();
            List<Truck> allTrucks = trucks.OrderBy(x => x.Brand).ToList();
            Catalog catalog = new Catalog()
            {
                Car = allCars,
                Truck = allTrucks
            };
            //Car = allCars,
            //Truck = allTrucks
            catalogs.Add(catalog);

            foreach (Catalog item in catalogs)
            {
                if (item.Car.Count > 0)
                {
                    Console.WriteLine("Cars:");
                    foreach (Car itemCar in allCars)
                    {
                        Console.WriteLine($"{itemCar.Brand}: {itemCar.Model} - {itemCar.HorsePower}hp");
                    }

                }
                if (item.Truck.Count > 0)
                {
                    Console.WriteLine("Trucks:");
                    foreach (Truck itemTruck in allTrucks)
                    {
                        Console.WriteLine($"{itemTruck.Brand}: {itemTruck.Model} - {itemTruck.Weight}kg");
                    }
                }
            }
        }
    }
}
