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

    public class StartUp
    {
        private static IMapper mapper;

        private static string filePath;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            DatasetsFilePath("parts.xml");
            string xml = File.ReadAllText(filePath);
            Console.WriteLine(ImportParts(context, xml));

        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            ImportPartDto[] partsDtos;
            var validSupplierId = context.Suppliers.Select(x => x.Id);

            using (var reader = new StringReader(inputXml))
            {
                partsDtos = ((ImportPartDto[])serializer.Deserialize(reader))
                    .Where(IsValid)
                    .Where(p => validSupplierId.Contains(p.SupplierId))
                    .ToArray();
            }

            InitializeMapper();

            Part[] parts = mapper.Map<Part[]>(partsDtos);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
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