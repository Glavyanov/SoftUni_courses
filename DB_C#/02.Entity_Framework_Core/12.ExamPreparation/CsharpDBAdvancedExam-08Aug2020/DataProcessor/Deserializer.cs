namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var games = JsonConvert.DeserializeObject<ImportGamesJsonDto[]>(jsonString);

            foreach (var g in games)
            {
                if (!IsValid(g))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                Game game = new Game()
                {
                    Name = g.Name,
                    Price = g.Price,
                    ReleaseDate = DateTime.ParseExact(g.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };
                var developer = context.Developers.FirstOrDefault(d => d.Name == g.Developer);
                if (developer == null)
                {
                    developer = new Developer() { Name = g.Developer };
                }
                game.Developer = developer;
                var genre = context.Genres.FirstOrDefault(gr => gr.Name == g.Genre);
                if (genre == null)
                {
                    genre = new Genre() { Name = g.Genre };
                }
                game.Genre = genre;

                foreach (var tagDto in g.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(gt => gt.Name == tagDto) ??
                        new Tag() { Name = tagDto };

                    game.GameTags.Add(new GameTag() { Tag = tag });

                }
                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var users = JsonConvert.DeserializeObject<ImportUserJsonDto[]>(jsonString);
            List<User> validUsers = new List<User>();

            foreach (var u in users)
            {
                if (!IsValid(u))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                bool invalid = false;
                foreach (var card in u.Cards)
                {
                    if (!IsValid(card))
                    {
                        sb.AppendLine("Invalid Data");
                        invalid = true;
                        break;
                    }
                }
                if (invalid)
                {
                    continue;
                }
                User user = new User()
                {
                    FullName = u.FullName,
                    Username = u.Username,
                    Email = u.Email,
                    Age = u.Age,

                };
                foreach (var c in u.Cards)
                {
                    Card card = new Card()
                    {
                        Number = c.Number,
                        Cvc = c.CVC,
                        Type = c.Type.Value
                    };
                    user.Cards.Add(card);
                }
                validUsers.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer serializer = 
                new XmlSerializer(typeof(ImportPurchaseXmlDto[]), new XmlRootAttribute("Purchases"));
            using StringReader reader = new StringReader(xmlString);
            StringBuilder sb = new StringBuilder();
            var purchases = (ImportPurchaseXmlDto[])serializer.Deserialize(reader);
            List<Purchase> validPurchases = new List<Purchase>();

            foreach (var p in purchases)
            {
                if (!IsValid(p))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var title = context.Games.FirstOrDefault(g => g.Name == p.Title);
                if (title == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var card = context.Cards.FirstOrDefault(c => c.Number == p.Card);
                if (card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var purchase = new Purchase()
                {
                    GameId = title.Id,
                    Type = (PurchaseType)p.Type,
                    ProductKey = p.Key,
                    CardId = card.Id,
                    Date = DateTime.ParseExact(p.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };
                validPurchases.Add(purchase);
                sb.AppendLine($"Imported {p.Title} for {context.Users.FirstOrDefault(u => u.Cards.Any(c => c.Id == card.Id)).Username}");
            }
            context.AddRange(validPurchases);
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