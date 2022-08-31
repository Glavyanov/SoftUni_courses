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

            DatasetsFilePath("cars.xml");
            string xml = File.ReadAllText(filePath);
            Console.WriteLine(ImportCars(context, xml));
            
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));
            using StringReader reader = new StringReader(inputXml);

            ImportCarDto[] carsDtos = ((ImportCarDto[])serializer.Deserialize(reader)).Where(IsValid).ToArray();
            int[] validPartsIDs = context.Parts.Select(x => x.Id).ToArray();
            List<Car> cars = new List<Car>();

            InitializeMapper();
            foreach (ImportCarDto carDto in carsDtos)
            {
                Car car = mapper.Map<Car>(carDto);
                /*var parts = carDto.Parts
                      .GroupBy(p => p.PartId)
                      .Select(g => g.First())
                      .ToList();*/

                foreach (var part in carDto.Parts.Select(x => x.PartId).Distinct())
                {

                    if (validPartsIDs.Contains(part))
                    {
                        car.PartCars.Add(new PartCar { PartId = part });
                    }
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
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