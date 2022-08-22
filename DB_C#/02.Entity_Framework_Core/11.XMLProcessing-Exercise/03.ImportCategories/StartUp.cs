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

            DatasetsFilePath("categories.xml");
            string xml = File.ReadAllText(filePath);
            Console.WriteLine(ImportCategories(context, xml));

        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Categories");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), root);

            ImportCategoryDto[] importCategories;
            using (StringReader reader = new StringReader(inputXml))
            {
                importCategories = ((ImportCategoryDto[])serializer.Deserialize(reader)).Where(IsValid).ToArray();
            }

            InitializeMapper();
            Category[] categories = mapper.Map<Category[]>(importCategories);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
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