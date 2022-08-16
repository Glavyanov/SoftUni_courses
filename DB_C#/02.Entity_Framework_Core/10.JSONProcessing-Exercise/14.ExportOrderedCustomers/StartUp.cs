using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;

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
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));

            ResultsFilePath("ordered-customers.json");
            File.WriteAllText(filePath, GetOrderedCustomers(context));

        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            ExportCustomerDto[] customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<ExportCustomerDto>()
                .ToArray();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }

    }
}