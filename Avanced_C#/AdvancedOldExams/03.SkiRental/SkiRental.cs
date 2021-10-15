using System;
using System.Collections.Generic;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> repo;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.repo = new List<Ski>();
        }

        public int Count => this.repo.Count;

        public void Add(Ski ski)
        {
            if (this.repo != null && this.Count < this.Capacity)
            {
                this.repo.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.repo != null)
            {
                if (this.repo.Any(x => x.Manufacturer == manufacturer && x.Model == model))
                {
                    Ski skiToRemove = this.repo.First(x => x.Manufacturer == manufacturer && x.Model == model);
                    this.repo.Remove(skiToRemove);
                    return true;
                }

            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (this.repo != null)
            {
                var sorted = new List<Ski>();
                sorted = this.repo.OrderByDescending(x => x.Year).ToList();
                var ski = sorted.FirstOrDefault();
                return ski;
            }
            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            if (this.repo != null)
            {
                Ski ski = this.repo.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
                return ski;
            }
            return null;
        }

        public string GetStatistics()
        {
            return $"The skis stored in {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.repo)}";
        }
    }
}
