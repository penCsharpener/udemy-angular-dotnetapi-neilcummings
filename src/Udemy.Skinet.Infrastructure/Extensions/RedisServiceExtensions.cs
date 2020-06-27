using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Udemy.Skinet.Infrastructure.Extensions {
    public static class RedisServiceExtensions {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration config) {
            services.AddSingleton<IConnectionMultiplexer>(_ => {
                var conf = ConfigurationOptions.Parse(config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(conf);
            });
            return services;
        }
    }
}
