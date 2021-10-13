using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car()
        {
            this.Weight = "n/a";
            this.Color = "n/a";
        }
        public Car(string model, Engine engine) : this()
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, string weight) : this(model, engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"{this.Model}:{Environment.NewLine}{this.Engine}{Environment.NewLine}  Weight: {this.Weight}{Environment.NewLine}  Color: {this.Color}";
        }
    }
}
