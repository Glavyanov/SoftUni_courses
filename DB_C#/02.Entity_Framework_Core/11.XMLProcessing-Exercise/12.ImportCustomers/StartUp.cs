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

    public class StartUp
    {
        private static IMapper mapper;

        private static string filePath;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            DatasetsFilePath("customers.xml");
            string xml = File.ReadAllText(filePath);
            Console.WriteLine(ImportCustomers(context, xml));
            
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            using StringReader reader = new StringReader(inputXml);

            ImportCustomerDto[] customersDtos =
                ((ImportCustomerDto[])serializer.Deserialize(reader)).Where(IsValid).ToArray();
            List<Customer> customers = new List<Customer>();

            InitializeMapper();
            foreach (var customerDto in customersDtos)
            {
                customers.Add(mapper.Map<Customer>(customerDto));
            }
            
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
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