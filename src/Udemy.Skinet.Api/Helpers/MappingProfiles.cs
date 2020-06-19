using AutoMapper;
using Udemy.Skinet.Api.Dtos;
using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Api.Helpers {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));
        }
    }
}
