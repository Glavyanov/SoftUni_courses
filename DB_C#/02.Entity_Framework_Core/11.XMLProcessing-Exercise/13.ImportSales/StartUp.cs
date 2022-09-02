namespace CarDealer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.CarDealerDtos;
    using Castle.Core.Resource;
    using System.Net.Http.Headers;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        private static IMapper mapper;

        private static string filePath;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            DatasetsFilePath("sales.xml");
            string xml = File.ReadAllText(filePath);
            Console.WriteLine(ImportSales(context, xml));
            
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));
            using StringReader reader = new StringReader(inputXml);
            List<int> validCarIDs = context.Cars
                        .AsNoTracking()
                        .Select(c => c.Id)
                        .ToList();

            ImportSaleDto[] salesDto = ((ImportSaleDto[])serializer.Deserialize(reader))
                .Where(IsValid)
                .Where(s => validCarIDs.Contains(s.CarId))
                .ToArray();

            InitializeMapper();
            List<Sale> sales = salesDto.Select(x => mapper.Map<Sale>(x)).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
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

        private static void InitializeMapper()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}