using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;
        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (this.cars.GetByName(carModel) == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            this.drivers.GetByName(driverName).AddCar(this.cars.GetByName(carModel));
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (this.drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            this.races.GetByName(raceName).AddDriver(this.drivers.GetByName(driverName));
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);

            }
            this.cars.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            var driver = new Driver(driverName);
            this.drivers.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            Race race = new Race(name, laps);
            this.races.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (this.races.GetByName(raceName).Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            var collection = this.races.GetByName(raceName).Drivers;
            int count = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in collection.OrderByDescending(d=> d.Car.CalculateRacePoints(this.races.GetByName(raceName).Laps)))
            {
                if (count == 0)
                {
                    sb.AppendLine($"Driver {item.Name} wins {raceName} race.");
                }
                else if (count == 1)
                {
                    sb.AppendLine($"Driver {item.Name} is second in {raceName} race.");

                }
                else if (count == 2)
                {
                    sb.AppendLine($"Driver {item.Name} is third in {raceName} race.");
                }
                count++;
                if (count == 3)
                {
                    break;
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
