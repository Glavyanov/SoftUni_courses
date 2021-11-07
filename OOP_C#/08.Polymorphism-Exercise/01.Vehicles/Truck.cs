namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirCondConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double distance)
        {
            if (base.FuelQuantity > 0)
            {
                double currConsumption = distance * (base.FuelConsumption + AirCondConsumption);
                if (base.FuelQuantity - currConsumption >= 0)
                {
                    base.FuelQuantity -= currConsumption;
                    return $"{this.GetType().Name} travelled {distance} km";
                }

            }
            return $"{this.GetType().Name} needs refueling";
        }

        public override void Refuel(double fuel)
        {
            if (fuel >= 0)
            {
                base.FuelQuantity += (fuel * 0.95);
            }
        }
       
    }
}
