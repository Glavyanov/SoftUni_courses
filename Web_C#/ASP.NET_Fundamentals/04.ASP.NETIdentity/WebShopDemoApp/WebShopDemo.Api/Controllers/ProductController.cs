using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Api.Controllers
{
    /// <summary>
    /// Public Controller for product
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        /// <summary>
        /// ProductController public ctor
        /// </summary>
        /// <param name="_productService"></param>
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAll());
        }

        /// <summary>
        /// Get All products starting witn G
        /// </summary>
        /// <returns>IEnumerable<![CDATA[<ProductDto>]]></returns>
        [HttpGet]
        [Route("getAllstartingwithG")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetAllStartingWithG()
        {
            return Ok(await productService.GetAllWhere(x => x.Name.StartsWith("g")));
        }

        /// <summary>
        /// Get All products witn price greater than or equal to 50
        /// </summary>
        /// <returns>IEnumerable<![CDATA[<ProductDto>]]></returns>
        [HttpGet]
        [Route("getAllWithPriceGreaterThanOrEqual50")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetAllWithPriceGreaterThanOrEqual50()
        {
            return Ok(await productService.GetAllWhere(x => x.Price >= 50));
        }
    }
}
