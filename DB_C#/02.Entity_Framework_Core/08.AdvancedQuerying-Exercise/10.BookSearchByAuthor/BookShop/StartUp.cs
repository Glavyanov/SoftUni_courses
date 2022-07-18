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
            Console.WriteLine(GetBooksByAuthor(db, Console.ReadLine()));

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var authorsAndBooks = context.Books
                .Include(a => a.Author)
                .ToArray()
                .Where(b => b.Author.LastName.StartsWith(input, StringComparison.OrdinalIgnoreCase))
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var a in authorsAndBooks)
            {
                sb.AppendLine($"{a.Title} ({a.FirstName} {a.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
