using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get=> this.name;
            
            private set
            {
                //To Check
                if (string.IsNullOrEmpty(value) || value.Length < 5 )
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }

        }

        public ICar Car => this.car;
        
        public int NumberOfWins => this.numberOfWins;
         
        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            this.car = car ?? throw new ArgumentNullException("Car cannot be null.");
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
    }
}
