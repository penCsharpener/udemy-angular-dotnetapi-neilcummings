﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Entities.OrderAggregate;

namespace Udemy.Skinet.Infrastructure.Data {
    public class StoreContext : DbContext {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == $"{nameof(Microsoft)}.{nameof(Microsoft.EntityFrameworkCore)}.{nameof(Microsoft.EntityFrameworkCore.Sqlite)}") {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
                    var properties = entityType.ClrType.GetProperties().Where(x => x.PropertyType == typeof(decimal));

                    foreach (var property in properties) {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    }
}
