using Microsoft.EntityFrameworkCore;
using Udemy.Skinet.Api.Entities;

namespace Udemy.Skinet.Api.Data {
    public class StoreContext : DbContext {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) {

        }

        public DbSet<Product> Products { get; set; }
    }
}
