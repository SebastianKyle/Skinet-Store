using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.Domain.Specifications
{
    /// <summary>
    /// Specification for counting total amount of products with given product brand and product type
    /// </summary>
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
            : base(x => 
                    (string.IsNullOrEmpty(productSpecParams.Search) || x.ProductName.Contains(productSpecParams.Search)) &&
                    (!productSpecParams.BrandId.HasValue || x.ProductBrandID == productSpecParams.BrandId) && 
                    (!productSpecParams.TypeId.HasValue || x.ProductTypeID == productSpecParams.TypeId)
            )
        {
            
        } 
    }
}