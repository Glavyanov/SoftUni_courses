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

            ResultsFilePath("customers-total-sales.json");
            File.WriteAllText(filePath, GetTotalSalesByCustomer(context));

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sales = context.Customers
                .Where(c => c.Sales.Any())
                .Select(s => new
                {
                    fullName = s.Name,
                    boughtCars = s.Sales.Count,
                    spentMoney = s.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }

    }
}