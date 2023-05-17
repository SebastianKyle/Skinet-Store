using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.DTO
{
    public class ProductBrandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class ProductBrandResponseExtensions
    {
        public static ProductBrandResponse ToProductBrandResponse(this ProductBrand productBrand)
        {
            ProductBrandResponse newProductBrandResponse = new ProductBrandResponse() {
                Id = productBrand.Id,
                Name = productBrand.Name
            };

            return newProductBrandResponse;
        }
    }
}