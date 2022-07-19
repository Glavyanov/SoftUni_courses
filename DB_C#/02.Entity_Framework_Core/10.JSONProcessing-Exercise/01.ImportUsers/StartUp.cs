using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
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

            InitializeFilePath("users.json");
            string inputJson = File.ReadAllText(filePath);

            Console.WriteLine(ImportUsers(context, inputJson));

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] usersImportDto = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson)
                                                        .Where(IsValid)
                                                        .ToArray();
            User[] users = Mapper.Map<User[]>(usersImportDto);
            
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        private static void InitializeFilePath(string file)
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