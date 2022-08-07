namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCoachesXmlDto[]), new XmlRootAttribute("Coaches"));
            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            XmlSerializerNamespaces namez = new XmlSerializerNamespaces();
            namez.Add(string.Empty, string.Empty);

            var coaches = context.Coaches
                .ToArray()
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachesXmlDto
                {
                    CoachName = c.Name,
                    FootballersCount = c.Footballers.Count,
                    Footbalers = c.Footballers.Select(x => new ExportFootbalersXmlDto
                    {
                        Name = x.Name,
                        Position = x.PositionType.ToString()
                    })
                    .OrderBy(f => f.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToArray();

            serializer.Serialize(writer, coaches, namez);

            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamWitnFootbalers = context.Teams
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .Select(e => new
                {
                    Name = e.Name,
                    Footballers = e.TeamsFootballers
                    .Where(f => f.Footballer.ContractStartDate >= date)
                    .Select(ft => new
                    {
                        FootballerName = ft.Footballer.Name,
                        ContractStartDate = ft.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = ft.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = ft.Footballer.BestSkillType.ToString(),
                        PositionType = ft.Footballer.PositionType.ToString()
                    })
                    .OrderByDescending(es => DateTime.Parse(es.ContractEndDate, CultureInfo.InvariantCulture))
                    .ThenBy(x => x.FootballerName)
                    .ToArray()

                })
                .OrderByDescending(x => x.Footballers.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teamWitnFootbalers, Formatting.Indented);
        }
    }
}
