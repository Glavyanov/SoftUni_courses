namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var games = context.Genres
				.Include(x => x.Games)
				.ThenInclude(x => x.Purchases)
				.ThenInclude(x => x.Game)
				.ToArray()
				.Where(x => genreNames.Contains(x.Name))
				.Select(g => new ExportGenreJsonDto()
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games.Where(x => x.Purchases.Any()).Select(ga => new ExportGameJsonDto()
					{
						Id = ga.Id,
						Title = ga.Name,
						Developer = ga.Developer.Name,
						Tags = string.Join(", ", ga.GameTags.Select(x => x.Tag.Name)),
						Players = ga.Purchases.Count()
					})
					.OrderByDescending(p => p.Players)
					.ThenBy(p => p.Id)
					.ToArray(),
					TotalPlayers = g.Games.Sum(x => x.Purchases.Count())
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id)
				.ToArray();

			return JsonConvert.SerializeObject(games, Formatting.Indented);
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users
				.ToList()
				.Where(x => x.Cards.Any(x => x.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(x => new ExportUserXmlDto()
				{
					UserName = x.Username,
					Purchases = x.Cards.SelectMany(c => c.Purchases.Where(x => x.Type.ToString() == storeType))
							.Select(p => new ExportPurchaseXmlDto()
							{
								Card = p.Card.Number,
								Cvc = p.Card.Cvc,
								Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
								Game = new ExportGameXmlDto()
								{
									Title = p.Game.Name,
									Genre = p.Game.Genre.Name,
									Price = p.Game.Price
								}

							})
							.OrderBy(p => p.Date)
							.ToArray(),
					TotalSpent = x.Cards.Sum(x => x.Purchases.Where(y => y.Type.ToString() == storeType).Sum(z => z.Game.Price))
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.UserName)
				.ToArray();

			XmlSerializer serializer
				 = new XmlSerializer(typeof(ExportUserXmlDto[]), new XmlRootAttribute("Users"));
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);
			StringBuilder sb = new StringBuilder();
			using StringWriter stringWriter = new StringWriter(sb);
			serializer.Serialize(stringWriter, users, namespaces);

			return sb.ToString().TrimEnd();
		}
	}
}