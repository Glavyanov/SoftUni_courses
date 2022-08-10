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

            ResultsFilePath("categories-by-products.json");
            File.WriteAllText(filePath, GetCategoriesByProductsCount(context));

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoryByProductDto[] categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<ExportCategoryByProductDto>()
                .ToArray();
            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }
    }
}