using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Racer racer)
        {
            if (this.data.Count < Capacity)
            {
                this.data.Add(racer);
            }

        }

        public bool Remove(string name)
        {
            return this.data.Remove(this.data.FirstOrDefault(r => r.Name == name));
        }

        public Racer GetOldestRacer()
        {
                var dataOrder = this.data.OrderByDescending(r => r.Age).ToList();
                return dataOrder.FirstOrDefault();

        }

        public Racer GetRacer(string name)
        {
                return this.data.FirstOrDefault(r => r.Name == name);

        }

        public Racer GetFastestRacer()
        {
                var dataOrder = this.data.OrderByDescending(r => r.Car.Speed).ToList();
                return dataOrder.FirstOrDefault();

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var item in this.data)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
