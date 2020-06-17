﻿using Microsoft.EntityFrameworkCore;
using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Infrastructure.Data {
    public class StoreContext : DbContext {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
