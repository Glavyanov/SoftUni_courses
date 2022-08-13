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

            DatasetsFilePath("cars.json");
            string json = File.ReadAllText(filePath);
            Console.WriteLine(ImportCars(context, json));

        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson)
                .Where(IsValid)
                .ToArray();

            List<Car> cars = new List<Car>();
            foreach (var carDto in carDtos)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,

                };
                foreach (var part in carDto.PartsId.Distinct())
                {
                    var partcar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = part
                    };
                    car.PartCars.Add(partcar);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
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