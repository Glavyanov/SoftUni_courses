namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            Console.WriteLine(GetBooksReleasedBefore(db, Console.ReadLine()));

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            string[] dateEl = date.Split("-", StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(dateEl[2]);
            int month = int.Parse(dateEl[1]);
            int day = int.Parse(dateEl[0]);

            var borderDate = new DateTime(year, month, day);

            StringBuilder sb = new StringBuilder();
            var books = context.Books
                .Where(b => b.ReleaseDate.Value < borderDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");

            }
            return sb.ToString().TrimEnd();
        }

    }
}
