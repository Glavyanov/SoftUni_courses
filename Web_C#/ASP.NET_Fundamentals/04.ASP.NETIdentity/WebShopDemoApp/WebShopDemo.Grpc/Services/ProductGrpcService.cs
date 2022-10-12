using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Linq;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Services;

namespace WebShopDemo.Grpc.Services
{
    public class ProductGrpcService : Product.ProductBase
    {
        private readonly IProductService productService;

        public ProductGrpcService(IProductService _productService)
        {
            productService = _productService;
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            ProductList result = new ProductList();
            var products = await productService.GetAll();

            result.Items.AddRange(products.Select(p => new ProductItem()
            {
                Name = p.Name,
                Id = p.Id.ToString(),
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return result;
        }

        public override async Task<ProductList> GetAllMouse(Empty request, ServerCallContext context)
        {
            ProductList result = new ProductList();
            var products = await (productService as ProductService)!.GetAllWhere(x => x.Name.ToLower().Contains("mouse"));

            result.Items.AddRange(products.Select(p => new ProductItem()
            {
                Name = p.Name,
                Id = p.Id.ToString(),
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return result;
        }

        public override async Task<ProductList> GetAllByName(ProductRequest request, ServerCallContext context)
        {
            ProductList result = new ProductList();
            var products = await (productService as ProductService)!.GetAllWhere(x => x.Name.ToLower().Contains(request.Name));

            result.Items.AddRange(products.Select(p => new ProductItem()
            {
                Name = p.Name,
                Id = p.Id.ToString(),
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return result;
        }
    }
}
