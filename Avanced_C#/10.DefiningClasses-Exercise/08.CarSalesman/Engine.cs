using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }
        public Engine(string model, string power) : this()
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, string power, string displacement) : this(model, power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
        }
        public Engine(string model, string power, string displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
        public override string ToString()
        {

            return $"  {this.Model}:{Environment.NewLine}    Power: {this.Power}{Environment.NewLine}    Displacement: {this.Displacement}{Environment.NewLine}    Efficiency: {this.Efficiency}";
        }
    }
}
