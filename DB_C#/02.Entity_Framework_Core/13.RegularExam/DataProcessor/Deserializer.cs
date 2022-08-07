namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachXmlDto[]), new XmlRootAttribute("Coaches"));
            using StringReader reader = new StringReader(xmlString);

            var coaches = (ImportCoachXmlDto[])serializer.Deserialize(reader);
            StringBuilder sb = new StringBuilder();
            List<Coach> validCoaches = new List<Coach>();

            foreach (var c in coaches)
            {
                if (!IsValid(c))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Footballer> validFootballers = new List<Footballer>();

                if (c.Footballers.Any())
                {
                    foreach (var f in c.Footballers)
                    {
                        if (!IsValid(f))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                        bool validStartDate = DateTime.TryParseExact(f.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime startDate);

                        bool validEndDate = DateTime.TryParseExact(f.ContractEndDate,"dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime endDate);

                        if (!validStartDate || !validEndDate || startDate > endDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool validBestSkill = Enum.TryParse(f.BestSkillType, out BestSkillType bestSkill);
                        bool validPosition= Enum.TryParse(f.PositionType, out PositionType positionType);
                        if (!validBestSkill || !validPosition)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        validFootballers.Add(new Footballer() 
                        {
                            Name = f.Name,
                            ContractStartDate = startDate,
                            ContractEndDate = endDate,
                            BestSkillType = bestSkill,
                            PositionType = positionType

                        });
                    }
                }
                Coach coach = new Coach 
                {
                    Name = c.Name,
                    Nationality = c.Nationality,
                    Footballers = new HashSet<Footballer>()
                };
                coach.Footballers = validFootballers;

                validCoaches.Add(coach);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teams = JsonConvert.DeserializeObject<ImportTeamJsonDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            var validTeams = new List<Team>();
            foreach (var t in teams)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrWhiteSpace(t.Trophies) || int.Parse(t.Trophies) <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var validFootbalers = context.Footballers.Select(x => x.Id).ToList();
                var validFootbalersToAdd = new List<TeamFootballer>();
                foreach (var f in t.Footballers.Distinct())
                {
                    if (!validFootbalers.Any(x => x == f))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var teamFootballer = new TeamFootballer()
                    {
                        FootballerId = f
                    };
                    validFootbalersToAdd.Add(teamFootballer);
                }
                Team team = Mapper.Map<Team>(t);
                team.TeamsFootballers = validFootbalersToAdd;
                validTeams.Add(team);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, validFootbalersToAdd.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
