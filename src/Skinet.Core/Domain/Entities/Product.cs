using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.DTO;

namespace Skinet.Core.Domain.Entities
{
    /// <summary>
    /// Entity class represent a product in store
    /// </summary>
    public class Product : BaseEntity
    {
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
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Product type id
        /// </summary>
        public int ProductTypeID { get; set; }

        /// <summary>
        /// Brand of product
        /// </summary>
        public ProductBrand ProductBrand { get; set; }

        /// <summary>
        /// Product brand id
        /// </summary>
        public int ProductBrandID { get; set; }
    }

    /// <summary>
    /// Extension for converting from DTO object (ProductAddRequest) to Product object
    /// </summary>
    public static class ProductAddRequestExtensions
    {
        /// <summary>
        /// Create a new Product object based on the ProductAddRequest
        /// </summary>
        /// <param name="productAddRequest">ProductAddRequest to convert</param>
        /// <returns>The converted object of Product type</returns>
        public static Product ToProduct(this ProductAddRequest productAddRequest)
        {
            Random random = new Random();
            Product product = new Product() {
                Id = random.Next(0, 100000),
                ProductName = productAddRequest.ProductName,
                Description = productAddRequest.Description,
                Price = productAddRequest.Price,
                PictureUrl = productAddRequest.PictureUrl,
                ProductType = productAddRequest.ProductType,
                ProductTypeID = productAddRequest.ProductType.Id,
                ProductBrand = productAddRequest.ProductBrand,
                ProductBrandID = productAddRequest.ProductBrand.Id
            };

            return product;
        }
    }
}