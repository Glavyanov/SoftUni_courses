using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double AirCondConsumption = 1.4;

        public Bus(double tankCapacity, double fuelConsumption, double fuelQuantity)
            : base(tankCapacity, fuelConsumption, fuelQuantity)
        {
        }

        public bool AirCondOn { get; set; } = true;

        public override string Drive(double distance)
        {
            if (this.FuelQuantity > 0)
            {
                double currConsumption = distance * (this.FuelConsumption + AirCondConsumption);
                if (!this.AirCondOn)
                {
                    currConsumption = distance * this.FuelConsumption;
                }

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
