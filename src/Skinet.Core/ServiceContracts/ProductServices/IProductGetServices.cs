using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Specifications;
using Skinet.Core.DTO;
using Skinet.Core.Helpers;

namespace Skinet.Core.ServiceContracts.ProductServices
{
    /// <summary>
    /// An interface represeting a service that perform operations of retrieving product details
    /// </summary>
    public interface IProductGetServices
    {
        Task<ProductResponse?> GetProductByIdAsync(int productID);

        Task<Pagination<ProductResponse>> GetProductsAsync(ProductSpecParams productSpecParams);

        Task<List<ProductBrandResponse>> GetProductBrandsAsync();

        Task<List<ProductTypeResponse>> GetProductTypesAsync();
    }
}