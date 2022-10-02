using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Core.Data;
using ShoppingList.Core.Models;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShoppingListDbContext data;

        public ProductsController(ShoppingListDbContext _data)
        {
            this.data = _data;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await this.data.Products
                .AsNoTracking()
                .Where(x => x.IsActive)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            if (!ModelState.IsValid || productDto.Name.Length == 81)
            {
                return View(productDto);
            }
            Product product = new()
            {
                Name = productDto.Name
            };

            await this.data.Products.AddAsync(product);
            await this.data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await this.data.Products.FirstOrDefaultAsync(pr => pr.Id == id);
            if (product != null)
            {
                product.IsActive = false;
                await this.data.SaveChangesAsync();
            }

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await this.data.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return View(new ProductDto() { Name = product!.Name?? "", Id = product.Id});
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto productDto)
        {
            if (!ModelState.IsValid || productDto.Name.Length == 81)
            {
                return View(productDto);
            }

            var product = await this.data.Products.FirstOrDefaultAsync(p => p.Id == productDto.Id);

            if (product != null)
            {
                product.Name = productDto.Name;
                await this.data.SaveChangesAsync();
            }

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var productAndNotes = await this.data.Products
                .AsNoTracking()
                .Where(p => p.Id == id && p.IsActive)
                .Select(x => new ProductDetailsDto()
                {
                    ProductName = x.Name,
                    ProductNotes = x.ProductNotes.Select(n => new ProductNoteDto()
                    {
                        Id = n.Id,
                        Content = n.Content
                    })
                    .ToList()
                }).FirstOrDefaultAsync();

            if(productAndNotes == null)
            {
                return BadRequest();
            }

            if (productAndNotes?.ProductNotes?.Count == 0)
            {
                return View(new ProductDetailsDto() { ProductName = productAndNotes.ProductName, ProductNotes = new List<ProductNoteDto>() });
            }

            return View(productAndNotes);
        }
    }
}
