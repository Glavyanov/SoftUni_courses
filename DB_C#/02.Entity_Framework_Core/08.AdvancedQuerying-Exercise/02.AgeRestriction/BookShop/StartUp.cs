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
            Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine()));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            bool isParsed = Enum.TryParse(command, true, out AgeRestriction ageRestriction);
            if (isParsed)
            {
                var booksByRestrict = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .ToArray();
                foreach (var b in booksByRestrict)
                {
                    sb.AppendLine(b.Title);
                }

            }

            return sb.ToString().TrimEnd();
        }

    }
}
