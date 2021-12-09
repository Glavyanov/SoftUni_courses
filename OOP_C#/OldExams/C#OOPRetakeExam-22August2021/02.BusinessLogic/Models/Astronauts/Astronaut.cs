using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;
        private bool createOxygen = true;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name),"Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0 && createOxygen)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                createOxygen = false;
                this.oxygen = value;
                if (this.oxygen < 0)
                {
                    this.oxygen = 0;
                }
            }
        }

        public bool CanBreath => this.oxygen > 0;

        public IBag Bag  => this.bag;
         
        public virtual void Breath()
        {
            this.Oxygen -= 10;
            
        }
    }
}
