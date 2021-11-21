using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SportCar sport = new SportCar(200, 10);
            Console.WriteLine(sport.Fuel);
            sport.Drive(1);
            Console.WriteLine(sport.Fuel);
            Car car = new Car(200, 9);
            Console.WriteLine(car.Fuel);
            car.Drive(1);
            Console.WriteLine(car.Fuel);
        }
    }
}
