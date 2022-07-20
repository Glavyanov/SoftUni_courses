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
            Console.WriteLine(CountCopiesByAuthor(db));

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCopies = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var b in bookCopies)
            {
                sb.AppendLine($"{b.FirstName} {b.LastName} - {b.Copies}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
