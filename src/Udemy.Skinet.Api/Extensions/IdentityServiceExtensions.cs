using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Skinet.Core.Entities.Identity;
using Udemy.Skinet.Infrastructure.Identity;

namespace Udemy.Skinet.Api.Extensions {
    public static class IdentityServiceExtensions {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services) {
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;
        }
    }
}
