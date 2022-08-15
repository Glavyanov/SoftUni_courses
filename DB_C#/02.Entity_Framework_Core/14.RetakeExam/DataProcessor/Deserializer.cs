namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            XmlSerializer serializer = 
                new XmlSerializer(typeof(ImportDespatcherXmlDto[]), new XmlRootAttribute("Despatchers"));
            using StringReader reader = new StringReader(xmlString);

            var despatchers = (ImportDespatcherXmlDto[])serializer.Deserialize(reader);
            List<Despatcher> validDesp = new List<Despatcher>();

            StringBuilder sb = new StringBuilder();
            foreach (var d in despatchers)
            {
                if (!IsValid(d))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher despatcher = new Despatcher()
                {
                    Name = d.Name,
                    Position = d.Position
                };

                foreach (var t in d.Trucks)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Truck truck = new Truck()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        VinNumber = t.VinNumber,
                        TankCapacity = t.TankCapacity,
                        CargoCapacity = t.CargoCapacity,
                        CategoryType = (CategoryType)t.CategoryType,
                        MakeType = (MakeType)t.MakeType
                    };
                    despatcher.Trucks.Add(truck);
                }
                validDesp.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }
            context.Despatchers.AddRange(validDesp);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ImportClientJsonDto[] importClientJsons = JsonConvert.DeserializeObject<ImportClientJsonDto[]>(jsonString);

            List<Client> clients = new List<Client>();
            StringBuilder sb = new StringBuilder();
            foreach (var c in importClientJsons)
            {
                if (!IsValid(c) || c.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client client = new Client()
                {
                    Name = c.Name,
                    Nationality = c.Nationality,
                    Type = c.Type,
                };

                var validTrucksDataBase = context.Trucks.Select(t => t.Id);

                foreach (var tr in c.Trucks.Distinct())
                {
                    if (!validTrucksDataBase.Contains(tr))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    client.ClientsTrucks.Add(new ClientTruck() { TruckId = tr });
                }
                clients.Add(client);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
