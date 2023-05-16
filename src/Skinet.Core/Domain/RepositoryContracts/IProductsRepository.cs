using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.Domain.Repository
{
    /// <summary>
    /// An interface that represents a repository that perform operarions like retrieve single product or products list
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Get a product based on the given id
        /// </summary>
        /// <param name="productID">Product id to search</param>
        Task<Product?> GetProduct(Guid productID);

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<List<Product>> GetProducts();

        /// <summary>
        /// Get all product brands
        /// </summary>
        Task<List<ProductBrand>> GetProductBrandsAsync();

        /// <summary>
        /// Get all product types
        /// </summary>
        Task<List<ProductType>> GetProductTypesAsync();
    }
}