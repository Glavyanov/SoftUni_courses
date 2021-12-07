using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, 65, 7.5)
        {
        }
        public override void Drive()
        {
            base.Drive();
            base.HorsePower = (int)Math.Round(base.HorsePower * 0.97);
        }
    }
}
