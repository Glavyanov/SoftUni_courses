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

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            DatasetsFilePath("customers.json");
            string json = File.ReadAllText(filePath);
            Console.WriteLine(ImportCustomers(context, json));

        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomerDto[] customersDto = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
            Customer[] customers = Mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        private static void DatasetsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets", file);
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}