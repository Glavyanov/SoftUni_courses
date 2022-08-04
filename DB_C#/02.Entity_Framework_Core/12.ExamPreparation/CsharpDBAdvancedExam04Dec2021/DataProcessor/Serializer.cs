namespace Theatre.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            // This works but not in Judge

            /*var theaters = context.Theatres
                .Include(e => e.Tickets)
                .Where(th => th.NumberOfHalls >= numbersOfHalls && th.Tickets.Count >= 20)
                .OrderByDescending(th => th.NumberOfHalls)
                .ThenBy(th => th.Name)
                .ProjectTo<ExportTheaterJsonDto>()
                .ToList();
            theaters.ForEach(t => t.Tickets = t.Tickets.OrderByDescending(t => t.Price).ToArray());*/

            var theaters = context.Theatres
                .Include(t => t.Tickets)
                .ToArray()
                .Where(th => th.NumberOfHalls >= numbersOfHalls && th.Tickets.Count >= 20)
                .Select(th => new ExportTheaterJsonDto
                {
                    Name = th.Name,
                    NumberOfHalls = th.NumberOfHalls,
                    TotalIncome = th.Tickets.Sum(t => t.RowNumber >= 1 && t.RowNumber <= 5 ? t.Price : 0),
                    Tickets = th.Tickets.Select(t => new ExportTicketJsonDto
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })
                    .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .OrderByDescending(t => t.Price)
                    .ToArray()
                })
                .OrderByDescending(th => th.NumberOfHalls)
                .ThenBy(th => th.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayXmlDto[]), new XmlRootAttribute("Plays"));
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var plays = context.Plays
                .Include(p => p.Casts)
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayXmlDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating != 0 ? p.Rating.ToString() : "Premier",
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(c => c.IsMainCharacter).Select(c => new ExportActorXmlDto
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(a => a.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            serializer.Serialize(writer, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
