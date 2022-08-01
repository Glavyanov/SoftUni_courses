
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Include(s => s.Guns)
                .ToArray()
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns.Where(gun => gun.GunType.ToString() == "AntiAircraftGun")
                                  .Select(g => new
                                  {
                                      GunType = g.GunType.ToString(),
                                      GunWeight = g.GunWeight,
                                      BarrelLength = g.BarrelLength,
                                      Range = g.Range > 3000 ? "Long-range" : "Regular range"
                                  })
                                  .OrderByDescending(g => g.GunWeight)
                                  .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(e => new ExportGunXmlDto
                {
                    ManufacturerName = e.Manufacturer.ManufacturerName,
                    GunType = e.GunType.ToString(),
                    GunWeight = e.GunWeight,
                    BarrelLength = e.BarrelLength,
                    Range = e.Range,
                    Countries = e.CountriesGuns.Where(c => c.Country.ArmySize > 4500000).Select(c => new ExportCountryXmlDto
                    {
                        Country = c.Country.CountryName,
                        ArmySize = c.Country.ArmySize
                    })
                    .OrderBy(c => c.ArmySize)
                    .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportGunXmlDto[]), new XmlRootAttribute("Guns"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, guns, namespaces);

            return sb.ToString();
        }
    }
}
