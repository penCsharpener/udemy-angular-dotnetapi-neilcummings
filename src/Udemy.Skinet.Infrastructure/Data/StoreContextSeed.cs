using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Entities.OrderAggregate;

namespace Udemy.Skinet.Infrastructure.Data {
    public class StoreContextSeed {
        private const string SeedBasePath = "../../StudentAssets/SeedData";

        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory) {
            try {
                if (Directory.Exists(SeedBasePath)) {
                    if (!context.ProductBrands.Any()) {
                        if (SeedFromFile<ProductBrand>("brands.json", out var entities)) {
                            await context.ProductBrands.AddRangeAsync(entities);
                        }
                    }

                    if (!context.ProductTypes.Any()) {
                        if (SeedFromFile<ProductType>("types.json", out var entities)) {
                            await context.ProductTypes.AddRangeAsync(entities);
                        }
                    }

                    if (!context.Products.Any()) {
                        if (SeedFromFile<Product>("products.json", out var entities)) {
                            await context.Products.AddRangeAsync(entities);
                        }
                    }

                    if (!context.DeliveryMethods.Any()) {
                        if (SeedFromFile<DeliveryMethod>("delivery.json", out var entities)) {
                            await context.DeliveryMethods.AddRangeAsync(entities);
                        }
                    }

                    await context.SaveChangesAsync();
                }
            } catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }

        public static bool SeedFromFile<T>(string fileName, out List<T> items) where T : class, new() {
            var brandsPath = Path.Combine(SeedBasePath, fileName);

            if (File.Exists(brandsPath)) {
                var brandsData = File.ReadAllText(brandsPath);
                items = JsonSerializer.Deserialize<List<T>>(brandsData);
                return true;
            }

            items = new List<T>();
            return false;
        }
    }
}
