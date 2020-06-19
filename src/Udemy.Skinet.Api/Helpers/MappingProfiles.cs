using AutoMapper;
using Udemy.Skinet.Api.Dtos;
using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Api.Helpers {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Product, ProductToReturnDto>();
        }
    }
}
