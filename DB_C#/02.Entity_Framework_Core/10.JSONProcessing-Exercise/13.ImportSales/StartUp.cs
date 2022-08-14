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

            DatasetsFilePath("sales.json");
            string json = File.ReadAllText(filePath);
            Console.WriteLine(ImportSales(context, json));

        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ImportSalesDto[] salesDtos = JsonConvert.DeserializeObject<ImportSalesDto[]>(inputJson);
            Sale[] sales = Mapper.Map<Sale[]>(salesDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
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