using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Skinet.Core.Domain.Entities;
using Skinet.Core.DTO;

namespace Skinet.Core.Helpers
{
  public class ProductPictureUrlResolver : IValueResolver<Product, ProductResponse, string>
  {
    private readonly IConfiguration _configuration;
    public ProductPictureUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _configuration["ApiUrl"] + source.PictureUrl;
        }

        return null;
    }
  }
}