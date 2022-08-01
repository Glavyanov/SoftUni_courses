namespace Artillery.DataProcessor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCountriesXmlDto[]), new XmlRootAttribute("Countries"));
            using StringReader reader = new StringReader(xmlString);
            var countries = (ImportCountriesXmlDto[])serializer.Deserialize(reader);

            ICollection<Country> validCountries = new List<Country>();
            foreach (var c in countries)
            {
                if (!IsValid(c))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }
                sb.AppendLine($"Successfully import {c.CountryName} with {c.ArmySize} army personnel.");
                Country country = Mapper.Map<Country>(c);
                validCountries.Add(country);
            }
            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportManufacturerXmlDto[]), new XmlRootAttribute("Manufacturers"));
            using StringReader reader = new StringReader(xmlString);
            var manufacturers = (ImportManufacturerXmlDto[])serializer.Deserialize(reader);

            ICollection<Manufacturer> validManufacturers = new List<Manufacturer>();

            foreach (var m in manufacturers)
            {

                if (validManufacturers.Any(e => e.ManufacturerName == m.ManufacturerName))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                if (!IsValid(m))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                Manufacturer manufacturer = Mapper.Map<Manufacturer>(m);
                validManufacturers.Add(manufacturer);
                sb.AppendLine($"Successfully import manufacturer {m.ManufacturerName} founded in {string.Join(", ", m.Founded.Split(", ").TakeLast(2))}.");
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportShellXmlDto[]), new XmlRootAttribute("Shells"));
            using StringReader reader = new StringReader(xmlString);
            var shells = (ImportShellXmlDto[])serializer.Deserialize(reader);

            ICollection<Shell> validShells= new List<Shell>();

            foreach (var s in shells)
            {
                if (!IsValid(s))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                Shell shell = Mapper.Map<Shell>(s);
                validShells.Add(shell);
                sb.AppendLine($"Successfully import shell caliber #{s.Caliber} weight {s.ShellWeight} kg.");
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            ImportGunJsonDto[] guns = JsonConvert.DeserializeObject<ImportGunJsonDto[]>(jsonString);

            ICollection<Gun> validGuns = new List<Gun>();
            StringBuilder sb = new StringBuilder();

            foreach (var g in guns)
            {
                if (!IsValid(g))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }
                bool validEnum = Enum.TryParse<GunType>(g.GunType, out GunType type);
                if (!validEnum)
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                Gun gun = Mapper.Map<Gun>(g);
                gun.GunType = type;
                validGuns.Add(gun);
                sb.AppendLine($"Successfully import gun {g.GunType} with a total weight of {g.GunWeight} kg. and barrel length of {g.BarrelLength} m.");
            }
            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
