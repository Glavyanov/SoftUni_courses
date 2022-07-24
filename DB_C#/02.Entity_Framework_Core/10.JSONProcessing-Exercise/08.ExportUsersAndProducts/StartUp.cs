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

            ResultsFilePath("users-and-products.json");
            File.WriteAllText(filePath, GetUsersWithProducts(context));

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            
            ExportUsersAndProductsDto usersWithProducts = new ExportUsersAndProductsDto
            {
                
                Users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportUsersSoldProductsDto()
                    {
                        Count = u.ProductsSold.Any() ? u.ProductsSold.Count(p => p.BuyerId.HasValue) : 0,
                        Products = u.ProductsSold.Where(pr => pr.BuyerId.HasValue)
                        .Select(p => new ExportUserSoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()
                    }

                })
                .OrderByDescending(p => p.SoldProducts.Count)
                .ToArray()

            };
            var usersWithCount = new
            {
                usersCount = usersWithProducts.Users.Any() ? usersWithProducts.Users.Length : 0,
                users = usersWithProducts.Users
            };

            string json = JsonConvert.SerializeObject(usersWithCount, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }

    }
}