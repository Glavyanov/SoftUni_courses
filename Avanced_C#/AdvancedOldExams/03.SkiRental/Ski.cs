﻿namespace SkiRental
{
    public class Ski
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public Ski(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"{this.Manufacturer} - {this.Model} - {this.Year}";
        }
    }
}
