using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
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

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            /*ResultsFilePath("suppliers.json");
            string json = File.ReadAllText(filePath);*/
            

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            throw new NotImplementedException();
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }
    }
}