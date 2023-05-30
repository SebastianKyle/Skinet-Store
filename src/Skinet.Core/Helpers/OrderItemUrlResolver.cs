using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Skinet.Core.Domain.Entities.OrderAggregate;
using Skinet.Core.DTO;

namespace Skinet.Core.Helpers
{
  public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDTO, string>
  {
    private readonly IConfiguration _config;

    public OrderItemUrlResolver(IConfiguration config)
    {
      _config = config;
    }

    public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl)) {
            return _config["ApiUrl"] + source.ItemOrdered.PictureUrl;
        }

        return null;
    }
  }
}