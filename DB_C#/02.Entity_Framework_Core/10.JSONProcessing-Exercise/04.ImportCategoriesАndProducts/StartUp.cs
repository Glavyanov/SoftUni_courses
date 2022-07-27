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

            DatasetsFilePath("categories-products.json");
            string inputJson = File.ReadAllText(filePath);
            Console.WriteLine(ImportCategoryProducts(context, inputJson));

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] categoryProductDtos = 
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson)
                           .Where(IsValid)
                           .ToArray();
            CategoryProduct[] categoryProducts = Mapper.Map<CategoryProduct[]>(categoryProductDtos);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        private static void DatasetsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets",file);
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}