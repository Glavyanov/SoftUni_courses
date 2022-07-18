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
            Console.WriteLine(GetBookTitlesContaining(db, Console.ReadLine()));

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Select(b => b.Title)
                .ToArray()
                .Where(b => Regex.IsMatch(b, @$".*{input}.*", RegexOptions.IgnoreCase))
                .OrderBy(b => b)
                .ToArray();
            return string.Join(Environment.NewLine, titles);
        }

    }
}
