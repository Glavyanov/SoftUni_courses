using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        public Dictionary<string, Car> Participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Participants = new Dictionary<string, Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get;  set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get;  set; }

        public int Count => this.Participants.Count();

        public void Add(Car car)
        {
            if (this.Participants != null)
            {
                if (!this.Participants.ContainsKey(car.LicensePlate) && this.Capacity > this.Participants.Count && car.HorsePower <= this.MaxHorsePower)
                {
                    Participants.Add(car.LicensePlate, car);
                }
            }
            
        }

        public bool Remove(string licensePlate)
        {
            if (this.Participants != null)
            {
                if (this.Participants.ContainsKey(licensePlate))
                {
                    this.Participants.Remove(licensePlate);
                    return true;
                }
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            if (this.Participants != null)
            {
                return this.Participants.FirstOrDefault(p => p.Key == licensePlate).Value;
            }
            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (this.Participants != null)
            {
                var mostPowerfull = new Dictionary<string, Car>();
                mostPowerfull = this.Participants.OrderByDescending(p => p.Value.HorsePower).ToDictionary(k=> k.Key, v => v.Value);
                return mostPowerfull.FirstOrDefault().Value;
            }
            return null;
        }

        public string Report()
        {
            return $"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps}){Environment.NewLine}{string.Join(Environment.NewLine, this.Participants.Values)}";
            
        }
    }
}
