using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private readonly IMap map;
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }
            this.cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (!this.cars.Models.Any(c => c.VIN == carVIN))
            {
                throw new ArgumentException("Car cannot be found!");
            }
            ICar car = this.cars.Models.FirstOrDefault(c => c.VIN == carVIN);
            IRacer racer;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }
            this.racers.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (this.racers.FindBy(racerOneUsername) == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (this.racers.FindBy(racerTwoUsername) == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);
            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in this.racers.Models.OrderByDescending(m => m.DrivingExperience).ThenBy(m => m.Username))
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
