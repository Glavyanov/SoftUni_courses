using System;
using System.Collections.Generic;
using System.Text;

namespace _04.CarEngineAndTires
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

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
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
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
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
         : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
    }
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;
        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }
        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            set { this.cubicCapacity = value; }
        }
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
    public class Tire
    {
        private int year;
        private double pressure;
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

    }
}
