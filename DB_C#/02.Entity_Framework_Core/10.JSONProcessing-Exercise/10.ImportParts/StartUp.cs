using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Parts;
using CarDealer.DTO.Sales;
using CarDealer.DTO.Suppliers;
using CarDealer.Models;
using Newtonsoft.Json;

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

            DatasetsFilePath("parts.json");
            string json = File.ReadAllText(filePath);
            Console.WriteLine(ImportParts(context, json));

        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<int> ids = context.Suppliers.Select(s => s.Id).ToList();

            ImportPartDto[] partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson)
                .Where(p => ids.Contains(p.SupplierId))
                .ToArray();

            Part[] parts = Mapper.Map<Part[]>(partDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
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