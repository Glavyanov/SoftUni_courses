namespace MVC_Intro_Demo.Controllers
{
    using System.Text;
    using System.Text.Json;

    using MVC_Intro_Demo.Models;

    using Microsoft.AspNetCore.Mvc;
    using System.Net.Mime;
    using System.Net.Http.Headers;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class ProductsController : Controller
    {
        private readonly IEnumerable<ProductViewModel> products = 
            new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00M
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50M
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50M
            }
        };

        [HttpGet]
        [ActionName("My-Products")]
        public IActionResult All(string keyword) =>
            keyword != null ? View(this.products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())))
                            : View(this.products);

        [HttpGet]
        public IActionResult ById(int id)
        {
            ProductViewModel product = this.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult AllAsJson() => 
            Json(this.products, new JsonSerializerOptions() { WriteIndented = true });

        [HttpGet]
        public IActionResult AllAsText()
        {
            StringBuilder sb = new();
            foreach (var pr in this.products)
            {
                sb.AppendLine($"Product {pr.Id}: {pr.Name} - {pr.Price}lv");
            }

            return Content(sb.ToString());
        }

        [HttpGet]
        public IActionResult AllAsTextFile()
        {
            StringBuilder productsAsText = new();
            foreach (var pr in this.products)
            {
                productsAsText.AppendLine($"Product {pr.Id}: {pr.Name} - {pr.Price}lv");
            }

            Response.Headers.Add("Content-Disposition", "attachment;");
            byte[] textArr = Encoding.ASCII.GetBytes(productsAsText.ToString());
            
            return File(textArr, contentType: "text/plain");
        }

    }
}
