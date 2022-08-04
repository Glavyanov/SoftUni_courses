namespace Theatre.DataProcessor
{
    using AutoMapper;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlSerializer serializer = 
                new XmlSerializer(typeof(ImportPlayXmlDto[]), new XmlRootAttribute("Plays"));
            using StringReader reader = new StringReader(xmlString);
            ImportPlayXmlDto[] plays = (ImportPlayXmlDto[])serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            var validPlays = new List<Play>();
            foreach (var p in plays)
            {
                if (!IsValid(p))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;

                }
                TimeSpan time = TimeSpan.ParseExact(p.Duration, "c", CultureInfo.InvariantCulture);
                if (time.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool validEnum = Enum.TryParse<Genre>(p.Genre, out Genre genre);
                if (!validEnum)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;

                }
                Play play = Mapper.Map<Play>(p);
                validPlays.Add(play);
                sb.AppendLine(String.Format(SuccessfulImportPlay, p.Title, p.Genre.ToString(), p.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportCastXmlDto[]), new XmlRootAttribute("Casts"));

            using StringReader reader = new StringReader(xmlString);
            ImportCastXmlDto[] casts = (ImportCastXmlDto[])serializer.Deserialize(reader);

            List<Cast> validCasts = new List<Cast>();

            StringBuilder sb = new StringBuilder();
            foreach (var c in casts)
            {
                if (!IsValid(c))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = Mapper.Map<Cast>(c);
                validCasts.Add(cast);
                sb.AppendLine(String.Format(SuccessfulImportActor, c.FullName, c.IsMainCharacter ? "main" : "lesser"));

            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheatreJsonDto[] theatres = JsonConvert.DeserializeObject<ImportTheatreJsonDto[]>(jsonString);

            List<Theatre> validTheatres = new List<Theatre>();

            StringBuilder sb = new StringBuilder();
            foreach (var t in theatres)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Theatre theatre = Mapper.Map<Theatre>(t);
                List<Ticket> validTickets = new List<Ticket>();
                foreach (var ticket in t.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;

                    }
                    Ticket validTicket = Mapper.Map<Ticket>(ticket);
                    validTickets.Add(validTicket);
                }
                theatre.Tickets = validTickets;
                validTheatres.Add(theatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
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
