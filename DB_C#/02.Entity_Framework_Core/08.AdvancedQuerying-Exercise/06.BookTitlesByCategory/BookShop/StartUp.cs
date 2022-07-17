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
            Console.WriteLine(GetBooksByCategory(db, Console.ReadLine()));

        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(i => i.ToLower())
                                     .ToArray();
            var books = context.BooksCategories
                .Where(b => inputArr.Contains(b.Category.Name.ToLower()))
                .OrderBy(b => b.Book.Title)
                .Select(e => e.Book.Title)
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }

    }
}
