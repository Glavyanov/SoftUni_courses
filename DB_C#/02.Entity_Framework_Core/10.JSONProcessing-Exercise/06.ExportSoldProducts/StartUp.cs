using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.ExportDTOs;
using ProductShop.DTOs.ImportDTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext context = new ProductShopContext();

            //Console.WriteLine($"{context.Database.EnsureDeleted()}{Environment.NewLine}{context.Database.EnsureCreated()}");

            ResultsFilePath("users-sold-products.json");
            File.WriteAllText(filePath, GetSoldProducts(context));

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserWithSoldProductsDto[] users = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .ProjectTo<ExportUserWithSoldProductsDto>()
                    .ToArray();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }
    }
}