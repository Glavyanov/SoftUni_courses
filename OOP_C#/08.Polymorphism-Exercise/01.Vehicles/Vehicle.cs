namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value < 0)
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

        public abstract string Drive(double distance);

        public abstract void Refuel(double fuel);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
