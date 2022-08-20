using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Categories;
using ProductShop.Dtos.CategoryProducts;
using ProductShop.Dtos.Products;
using ProductShop.Dtos.Users;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static string filePath;

        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            DatasetsFilePath("products.xml");
            string xml = File.ReadAllText(filePath);
            Console.WriteLine(ImportProducts(context, xml));

        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Products");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), root);

            ImportProductDto[] importProducts;
            using (StringReader reader = new StringReader(inputXml))
            {
                importProducts = ((ImportProductDto[])serializer.Deserialize(reader)).Where(IsValid).ToArray();
            }

            InitializeMapper();
            Product[] products = mapper.Map<Product[]>(importProducts);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }

        private static void InitializeMapper()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

    }
}