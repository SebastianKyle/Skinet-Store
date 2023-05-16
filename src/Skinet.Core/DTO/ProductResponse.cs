using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.DTO
{
    /// <summary>
    /// A DTO class that represents a product - can be user as a return type for services
    /// </summary>
    public class ProductResponse
    {
        /// <summary>
        /// The unique ID of product
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// Name of product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Url of product picture
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Product type
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Brand of product
        /// </summary>
        public string ProductBrand { get; set; }
    }


    /// <summary>
    /// Extension for converting from Product object to ProductAddResponse object
    /// </summary>
    public static class ProductAddRequestExtensions
    {
        /// <summary>
        /// Create a new ProductAddResponse object based on the Product object
        /// </summary>
        /// <param name="product">Product to convert</param>
        /// <returns>The converted object of ProductAddResponse type</returns>
        public static ProductResponse ToProductResponse(this Product product)
        {
            ProductResponse productResponse = new ProductResponse() {
                ProductID = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductType = product.ProductType.Name,
                ProductBrand = product.ProductBrand.Name
            };

            return productResponse;
        }
    }
}