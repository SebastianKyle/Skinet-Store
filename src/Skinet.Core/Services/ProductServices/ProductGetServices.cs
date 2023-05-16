using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Repository;
using Skinet.Core.Domain.RepositoryContracts;
using Skinet.Core.Domain.Specifications;
using Skinet.Core.DTO;
using Skinet.Core.Helpers;
using Skinet.Core.ServiceContracts.ProductServices;

namespace Skinet.Core.Services.ProductServices
{
  public class ProductGetServices : IProductGetServices
  {
    private readonly IProductsRepository _productsRepository;
    private readonly IGenericRepository<Product> _productGenericRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandGenericRepo;
    private readonly IGenericRepository<ProductType> _productTypeGenericRepo;
    private readonly IMapper _mapper;

    public ProductGetServices(IProductsRepository productsRepository, IGenericRepository<Product> productGenericRepo
                                                                    , IGenericRepository<ProductBrand> productBrandGenericRepo
                                                                    , IGenericRepository<ProductType> productTypeGenericRepo
                                                                    , IMapper mapper)
    {
      _productsRepository = productsRepository;
      _productGenericRepo = productGenericRepo;
      _productBrandGenericRepo = productBrandGenericRepo;
      _productTypeGenericRepo = productTypeGenericRepo;
      _mapper = mapper;
    }

    public async Task<ProductResponse?> GetProductByIdAsync(Guid productID)
    {
      var spec = new ProductsWithTypesAndBrandsSpecification(productID) { };
      Product? matchingProduct = await _productGenericRepo.GetEntityWithSpec(spec);

      return _mapper.Map<Product, ProductResponse>(matchingProduct);
    }

    public async Task<Pagination<ProductResponse>> GetProductsAsync(ProductSpecParams productSpecParams)
    {
      var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);
      List<Product> productsList = await _productGenericRepo.ListAsync(spec);

      var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);
      var totalItems = await _productGenericRepo.CountAsync(countSpec);

      List<ProductResponse> productResponses = _mapper.Map<List<Product>, List<ProductResponse>>(productsList);

      return new Pagination<ProductResponse>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, productResponses);
    }

    public async Task<List<ProductBrandResponse>> GetProductBrandsAsync()
    {
      List<ProductBrand> brands = await _productBrandGenericRepo.ListAllAsync();

      return brands.Select(temp => temp.ToProductBrandResponse()).ToList();
    }

    public async Task<List<ProductTypeResponse>> GetProductTypesAsync()
    {
      List<ProductType> types = await _productTypeGenericRepo.ListAllAsync();

      return types.Select(temp => temp.ToProductTypeResponse()).ToList();
    }
  }
}