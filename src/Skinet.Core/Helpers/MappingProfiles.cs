using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Entities.Identity;
using Skinet.Core.Domain.Entities.OrderAggregate;
using Skinet.Core.DTO;

namespace Skinet.Core.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductResponse>().ForMember(m => m.ProductID, o => o.MapFrom(s => s.Id))
                                                 .ForMember(m => m.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                                                 .ForMember(m => m.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                                                 .ForMember(m => m.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());

            CreateMap<Skinet.Core.Domain.Entities.Identity.Address, AddressDTO>().ReverseMap();
            CreateMap<BasketItemDTO, BasketItem>().ReverseMap();
            CreateMap<CustomerBasketDTO, CustomerBasket>().ReverseMap();
            CreateMap<AddressDTO, Skinet.Core.Domain.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderReturnDTO>().ForMember(m => m.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price))
                                              .ForMember(m => m.DeliveryMethod, o => o.MapFrom(d => d.DeliveryMethod.ShortName));
            CreateMap<OrderItem, OrderItemDTO>().ForMember(m => m.ProductId, o => o.MapFrom(i => i.ItemOrdered.ProductItemId))
                                                .ForMember(m => m.ProductName, o => o.MapFrom(n => n.ItemOrdered.ProductName))
                                                .ForMember(m => m.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        } 
    }
}