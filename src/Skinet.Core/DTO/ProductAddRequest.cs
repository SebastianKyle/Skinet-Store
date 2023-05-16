using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.DTO
{
    /// <summary>
    /// DTO class represents a product - can be used while inserting / updating
    /// </summary>
    public class ProductAddRequest
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
        /// Brand of product
        /// </summary>
        public ProductBrand ProductBrand { get; set; }
    }
}