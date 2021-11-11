using System;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AirCondConsumption = 1.6;

        public Truck(double tankCapacity, double fuelConsumption, double fuelQuantity)
            : base(tankCapacity, fuelConsumption, fuelQuantity)
        {
        }

        public override string Drive(double distance)
        {
            if (this.FuelQuantity > 0)
            {
                double currConsumption = distance * (this.FuelConsumption + AirCondConsumption);
                if (this.FuelQuantity - currConsumption >= 0)
                {
                    this.FuelQuantity -= currConsumption;
                    return $"{this.GetType().Name} travelled {distance} km";
                }

            }
            return $"{this.GetType().Name} needs refueling";
        }

        public override void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if(fuel + this.FuelQuantity > this.TankCapacity)
                {
                    throw new Exception($"Cannot fit {fuel} fuel in the tank");
                }
                this.FuelQuantity += (fuel * 0.95);
            }
            else
            {
                throw new Exception("Fuel must be a positive number");
            }
        }
       
    }
}
