using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Skinet.Api.Extensions;
using Udemy.Skinet.Api.Helpers;
using Udemy.Skinet.Api.Middleware;
using Udemy.Skinet.Infrastructure.Data;
using Udemy.Skinet.Infrastructure.Extensions;

namespace Udemy.Skinet.Api {
    public class Startup {
        private const string CorsPolicy = "CorsPolicy";
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration) {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            services.AddRedis(_config);

            services.AddApplicationServices();
            services.AddSwaggerServices();
            services.AddCors(opt => {
                opt.AddPolicy(CorsPolicy, policy => {
                    policy
#if DEBUG
                    .AllowAnyOrigin()
#else
                    .WithOrigins("https://localhost:4200")
#endif
                    .AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors(CorsPolicy);

            app.UseAuthorization();
            app.UseSwaggerDocumenation();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
