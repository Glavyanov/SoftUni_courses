using Microsoft.AspNetCore.Mvc;
using MVC_Intro_Demo.Models;

namespace MVC_Intro_Demo.Controllers
{
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
        public IActionResult All()
        {
            return View(this.products);
        }

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

    }
}
