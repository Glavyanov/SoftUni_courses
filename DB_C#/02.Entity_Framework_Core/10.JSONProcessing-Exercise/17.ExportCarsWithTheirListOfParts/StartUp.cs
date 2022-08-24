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
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));

            ResultsFilePath("cars-and-parts.json");
            File.WriteAllText(filePath, GetCarsWithTheirListOfParts(context));

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context) =>
            JsonConvert.SerializeObject(context.Cars.ProjectTo<ExportCarWithPartsDto>().ToArray(), Formatting.Indented);

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }

    }
}