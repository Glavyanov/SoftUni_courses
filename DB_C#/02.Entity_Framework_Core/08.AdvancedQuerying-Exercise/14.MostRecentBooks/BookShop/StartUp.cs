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
            Console.WriteLine(GetMostRecentBooks(db));

        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.OrderByDescending(b => b.Book.ReleaseDate.Value)
                                           .Select(b => new
                                           {
                                               b.Book.Title,
                                               b.Book.ReleaseDate.Value.Year
                                           })
                                           .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var c in categories)
            {
                sb.AppendLine($"--{c.Name}");
                foreach (var b in c.Books)
                {
                    sb.AppendLine($"{b.Title} ({b.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
