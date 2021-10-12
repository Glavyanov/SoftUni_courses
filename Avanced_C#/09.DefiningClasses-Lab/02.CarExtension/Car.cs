using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CarExtension
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public void Drive(double distance)
        {
            double result = (distance * FuelConsumption) / 100;
            double currentFuel = FuelQuantity;
            currentFuel -= result;
            if (currentFuel < 0)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity = currentFuel;
            }

        }
        public string WhoAmI()
        {
            return $"Make: {this.Make}{Environment.NewLine}Model: {this.Model}{Environment.NewLine}" +
                $"Year: {this.Year}{Environment.NewLine}Fuel: {this.FuelQuantity:F2}L";
        }
    }
}
