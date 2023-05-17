using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skinet.Core.Domain.Entities;

namespace Skinet.Core.DTO
{
    public class ProductTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class ProductTypeExtensions
    {
        public static ProductTypeResponse ToProductTypeResponse(this ProductType productType)
        {
            ProductTypeResponse productTypeResponse = new ProductTypeResponse() {
                Id = productType.Id,
                Name = productType.Name
            };

            return productTypeResponse;
        }
    }
}