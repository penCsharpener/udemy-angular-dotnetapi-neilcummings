using AutoMapper;
using Microsoft.Extensions.Configuration;
using Udemy.Skinet.Api.Dtos;
using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Api.Helpers {
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string> {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context) {
            if (!string.IsNullOrEmpty(source.PictureUrl)) {
                return _configuration["ApiUrl"].Trim('/') + "/" + source.PictureUrl.Trim('/');
            }

            return null;
        }
    }
}
