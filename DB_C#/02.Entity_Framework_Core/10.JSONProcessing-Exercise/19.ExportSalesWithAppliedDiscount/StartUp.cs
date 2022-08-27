using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using AutoMapper;
using Newtonsoft.Json;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Parts;
using CarDealer.DTO.Sales;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Suppliers;

namespace CarDealer
{
    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            ResultsFilePath("sales-discounts.json");
            File.WriteAllText(filePath, GetSalesWithAppliedDiscount(context));

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(c => new
                {
                    car = new
                    {
                        c.Car.Make,
                        c.Car.Model,
                        c.Car.TravelledDistance,
                    },
                    customerName = c.Customer.Name,
                    Discount = c.Discount.ToString(),
                    price = c.Car.PartCars.Sum(y => y.Part.Price).ToString("F2"),
                    priceWithDiscount = (c.Car.PartCars.Sum(p => p.Part.Price) - c.Car.PartCars.Sum(p => p.Part.Price) * c.Discount / 100).ToString("F2")
                })
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }

    }
}