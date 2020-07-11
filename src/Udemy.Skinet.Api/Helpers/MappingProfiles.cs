﻿using AutoMapper;
using Udemy.Skinet.Api.Dtos;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Entities.Identity;

namespace Udemy.Skinet.Api.Helpers {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
        }
    }
}
