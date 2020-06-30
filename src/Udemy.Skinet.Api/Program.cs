using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities.Identity;
using Udemy.Skinet.Infrastructure.Data;
using Udemy.Skinet.Infrastructure.Identity;

namespace Udemy.Skinet.Api {
    public sealed class Program {
        public static async Task Main(string[] args) {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try {
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);

                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                    await identityContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
                } catch (System.Exception ex) {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration.");
                }

                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder => {
    webBuilder.UseStartup<Startup>();
});
        }
    }
}
