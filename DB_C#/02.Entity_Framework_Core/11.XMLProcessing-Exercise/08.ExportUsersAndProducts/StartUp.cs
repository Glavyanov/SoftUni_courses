namespace ProductShop
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Dtos.Users;
    using ProductShop.Dtos.Products;
    using ProductShop.Dtos.Categories;
    using ProductShop.Dtos.CategoryProducts;

    public class StartUp
    {
        private static string filePath;

        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            ResultsFilePath("users-and-products.xml");
            File.WriteAllText(filePath, GetUsersWithProducts(context));

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(u => u.ProductsSold.Any())
                .Select(x => new ExportUserWithProductsDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ExportSoldProductsDto()
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(p => new ExportProductWithNamePriceDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }

                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToArray();

            var usersRoot = new ExportUserDto()
            {
                Count = users.Length,
                Users = users.Take(10).ToArray()
            };

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, usersRoot, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }
    }
}