using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;
using static WebShopDemo.Core.Data.ValidationConstants.RolesConstants;
using static WebShopDemo.Core.Data.ValidationConstants.PolicyConstants;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>

    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAll();
            ViewData["Title"] = "Products";
            
            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = $"{Manager}, {Supervisor}")]
        public IActionResult Add()
        {
            var model = new ProductDto();
            ViewData["Title"] = "Add new product";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Policy = Deletable)]
        public IActionResult Delete() => RedirectToAction(nameof(Index));

        [HttpPost]
        [Authorize(Policy = Deletable)]
        public async Task<IActionResult> Delete([FromForm]string id)
        {
            Guid idGuid = Guid.Parse(id);
            await productService.Delete(idGuid);

            return RedirectToAction(nameof(Index));
        }
    }
}
