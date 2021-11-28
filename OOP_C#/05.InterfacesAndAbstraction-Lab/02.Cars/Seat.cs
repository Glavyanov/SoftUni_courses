
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                this.model = value;
            }
        }
        public string Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
            }
        }

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
            return $"{this.Color} {this.GetType().Name} {this.Model}{Environment.NewLine}{this.Start()}{Environment.NewLine}{this.Stop()}";
        }
    }
}
