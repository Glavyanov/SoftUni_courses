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
            Console.WriteLine(GetTotalProfitByCategory(db));

        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Total = c.CategoryBooks.Sum(c => c.Book.Copies * c.Book.Price)
                })
                .OrderByDescending(c => c.Total)
                .ThenBy(c => c.Name)
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Name} ${c.Total:F2}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
