using System;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double tankCapacity, double fuelConsumption, double fuelQuantity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value < 0 || value > this.TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                fuelConsumption = value;
            }
        }


        public double TankCapacity
        {
            get { return tankCapacity; }
            private set
            {
                if (value > 0)
                {
                    tankCapacity = value;
                }
            }
        }


        public abstract string Drive(double distance);

        public virtual void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if (fuel + this.FuelQuantity > this.TankCapacity)
                {
                    throw new Exception($"Cannot fit {fuel} fuel in the tank");
                }
                this.FuelQuantity += fuel;
            }
            else
            {
                throw new Exception("Fuel must be a positive number");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }

    }
}
