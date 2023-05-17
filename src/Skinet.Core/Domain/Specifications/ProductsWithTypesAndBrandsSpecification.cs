using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.Domain.Specifications
{
  /// <summary>
  /// Specification for applying expressions for queying products with brands, types, sorting and paging details
  /// </summary>
  public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
  {
    public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams)
      : base(x => 
             (string.IsNullOrEmpty(productSpecParams.Search) || x.ProductName.Contains(productSpecParams.Search)) &&
             (!productSpecParams.BrandId.HasValue || x.ProductBrandID == productSpecParams.BrandId) && 
             (!productSpecParams.TypeId.HasValue || x.ProductTypeID == productSpecParams.TypeId)
      )
    {
      AddInclude(x => x.ProductBrand);
      AddInclude(x => x.ProductType);
      AddOrderBy(x => x.ProductName);

      // When user selece a page index, we will skip the records of the previous pages, and take {pageSize} entities of remaining records
      ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

      if (!string.IsNullOrEmpty(productSpecParams.Sort))
      {
        switch (productSpecParams.Sort)
        {
          case "priceAsc": 
            AddOrderBy(p => p.Price);
            break;

          case "priceDesc": 
            AddOrderByDescending(p => p.Price);
            break;
          
          default:
            AddOrderBy(n => n.ProductName);
            break;
        }
      }
    }

    public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
    {
      AddInclude(x => x.ProductBrand);
      AddInclude(x => x.ProductType);
    }
  }
}