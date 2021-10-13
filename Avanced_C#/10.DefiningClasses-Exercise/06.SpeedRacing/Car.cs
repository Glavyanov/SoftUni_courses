using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuel, double consumption)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumptionPerKilometer = consumption;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        public static void Drive (Car car, double distance)
        {

            if (car.FuelAmount/car.FuelConsumptionPerKilometer >= distance)
            {
                car.TravelledDistance += distance;
                car.FuelAmount -= distance * car.FuelConsumptionPerKilometer; 
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
