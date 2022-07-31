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

            ResultsFilePath("users-and-products.json");
            File.WriteAllText(filePath, GetProductsInRange(context));

        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductDto[] exportProducts = context.Products
                                                       .Where(p => p.Price >=500 && p.Price <= 1000)
                                                       .OrderBy(p => p.Price)
                                                       .ProjectTo<ExportProductDto>()
                                                       .ToArray();

            string json = JsonConvert.SerializeObject(exportProducts, Formatting.Indented);

            return json;
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }
    }
}