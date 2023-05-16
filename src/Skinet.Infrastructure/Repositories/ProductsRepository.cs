using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Repository;
using Skinet.Infrastructure.Data;

namespace Skinet.Infrastructure.RepositoryContracts
{
  public class ProductsRepository : IProductsRepository
  {
    private readonly StoreDbContext _storeDbContext;

    public ProductsRepository(StoreDbContext storeDbContext)
    {
      _storeDbContext = storeDbContext;
    }

    public async Task<Product?> GetProduct(Guid productID)
    {
      Product? matchingProduct = await _storeDbContext.Products.Include(p => p.ProductBrand)
                                                         .Include(p => p.ProductType)
                                                         .FirstOrDefaultAsync(temp => temp.Id == productID);

      return matchingProduct;
    }

    public async Task<List<Product>> GetProducts()
    {
      List<Product> productsList = await _storeDbContext.Products.Include(p => p.ProductBrand)
                                                                 .Include(p => p.ProductType)
                                                                 .OrderByDescending(temp => temp.Id).ToListAsync();

      return productsList;
    }

    public async Task<List<ProductBrand>> GetProductBrandsAsync()
    {
      List<ProductBrand> brands = await _storeDbContext.ProductBrands.ToListAsync();

      return brands;
    }

    public async Task<List<ProductType>> GetProductTypesAsync()
    {
      List<ProductType> types = await _storeDbContext.ProductTypes.ToListAsync();

      return types;
    }
  }
}