using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
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

            /*context.Database.EnsureDeleted();
            context.Database.EnsureCreated();*/

            DatasetsFilePath("suppliers.json");
            string json = File.ReadAllText(filePath);
            Console.WriteLine(ImportSuppliers(context, json));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplierDto[] suppliersDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson)
                                                       .ToArray();

            var suppliers = Mapper.Map<Supplier[]>(suppliersDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        private static void DatasetsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets", file);
        }
    }
}