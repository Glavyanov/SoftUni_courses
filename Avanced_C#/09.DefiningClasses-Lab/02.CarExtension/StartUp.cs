using System;

namespace _02.CarExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 55;
            car.FuelConsumption = 4.3;
            car.Drive(1200);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
