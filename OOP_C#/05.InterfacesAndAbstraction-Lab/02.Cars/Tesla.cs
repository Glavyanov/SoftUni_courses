using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public int Battery { get ; set ; }
        public string Model { get; set ; }
        public string Color { get ; set ; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries{Environment.NewLine}{this.Start()}{Environment.NewLine}{this.Stop()}";
        }
    }
}
