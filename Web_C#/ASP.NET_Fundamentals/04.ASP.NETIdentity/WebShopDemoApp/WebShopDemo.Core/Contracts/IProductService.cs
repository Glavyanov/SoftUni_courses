using System.Linq.Expressions;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Contracts
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GetAll();

        /// <summary>
        /// Gets all products by specific condition
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GetAllWhere(Expression<Func<Product, bool>> search);

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        Task Add(ProductDto productDto);

        Task Delete(Guid id);
    }
}
