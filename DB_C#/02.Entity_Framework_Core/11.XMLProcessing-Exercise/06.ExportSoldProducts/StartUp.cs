using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Dtos.Users;
using ProductShop.Dtos.Products;
using ProductShop.Dtos.Categories;
using ProductShop.Dtos.CategoryProducts;

namespace ProductShop
{
    public class StartUp
    {
        private static string filePath;

        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            ResultsFilePath("users-sold-products.xml");
            File.WriteAllText(filePath, GetSoldProducts(context));

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializeMapper();
            ExportUserSoldProductsDto[] exportUsers = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUserSoldProductsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return Serialize(exportUsers, "Users");
        }

        private static void ResultsFilePath(string file)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results", file);
        }

        private static void InitializeMapper()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        private static string Serialize<T>( T[] dtoT, string root)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(root);
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), xmlRootAttribute);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, dtoT, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}