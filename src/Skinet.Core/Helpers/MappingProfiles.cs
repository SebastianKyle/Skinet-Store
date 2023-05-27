using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.Entities.Identity;
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

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<BasketItemDTO, BasketItem>().ReverseMap();
            CreateMap<CustomerBasketDTO, CustomerBasket>().ReverseMap();
        } 
    }
}