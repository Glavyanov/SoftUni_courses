namespace Trucks.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Include(x => x.Trucks)
                .Where(des => des.Trucks.Any())
                .ToArray()
                .Select(d => new ExportDespatcherXmlDto()
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks.Select(t => new ExportTruckXmlDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(x => x.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(x => x.TrucksCount)
                .ThenBy(x => x.DespatcherName)
                .ToArray();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportDespatcherXmlDto[]), new XmlRootAttribute("Despatchers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, despatchers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Include(x => x.ClientsTrucks)
                .ThenInclude(x => x.Truck)
                .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(cl => new ExportClientJsonDto()
                {
                    Name = cl.Name,
                    Trucks = cl.ClientsTrucks
                         .Where(t => t.Truck.TankCapacity >= capacity)
                         .Select(tr => new ExportTruckJsonDto()
                         {
                             TruckRegistrationNumber = tr.Truck.RegistrationNumber,
                             VinNumber = tr.Truck.VinNumber,
                             TankCapacity = tr.Truck.TankCapacity,
                             CargoCapacity = tr.Truck.CargoCapacity,
                             CategoryType = tr.Truck.CategoryType.ToString(),
                             MakeType = tr.Truck.MakeType.ToString()
                         })
                         .OrderBy(t => t.MakeType)
                         .ThenByDescending(c => c.CargoCapacity)
                         .ToArray()

                })
                .OrderByDescending(cl => cl.Trucks.Length)
                .ThenBy(cl => cl.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
