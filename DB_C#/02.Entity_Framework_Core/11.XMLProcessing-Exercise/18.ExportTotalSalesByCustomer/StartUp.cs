namespace CarDealer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.CarDealerDtos.Imports;
    using CarDealer.CarDealerDtos.Exports;
    

    public class StartUp
    {
        private static IMapper mapper;

        private static string filePath;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            ResultsFilePath("customers-total-sales.xml");
            File.WriteAllText(filePath, GetTotalSalesByCustomer(context));

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeMapper();
            ExportCustomerDto[] customers = context.Customers
                .AsNoTracking()
                .Where(c => c.Sales.Any())
                .ProjectTo<ExportCustomerDto>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            return Serialize(customers, "customers");
        }

        private static void InitializeMapper()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }

        private static string Serialize<T>(T[] dtoT, string root)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(root);
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), xmlRootAttribute);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, dtoT, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}