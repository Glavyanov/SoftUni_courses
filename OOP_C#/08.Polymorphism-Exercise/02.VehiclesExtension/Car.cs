using System;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double AirCondConsumption = 0.9;

        public Car(double tankCapacity, double fuelConsumption, double fuelQuantity) 
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

        public override void Refuel(double fuel) => base.Refuel(fuel);
        
    }
}
