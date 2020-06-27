using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Udemy.Skinet.Api.Errors;
using Udemy.Skinet.Core.Interfaces;
using Udemy.Skinet.Infrastructure.Data;

namespace Udemy.Skinet.Api.Extensions {
    public static class ApplicationServicesExtensions {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // needs to be configured last after the above
            services.Configure<ApiBehaviorOptions>(opt => {
                opt.InvalidModelStateResponseFactory = actionContext => {
                    var errors = actionContext.ModelState.Where(err => err.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                    var errorResponse = new ApiValidationErrorResponse {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
