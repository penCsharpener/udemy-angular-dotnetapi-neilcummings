using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udemy.Skinet.Core.Entities.Identity;

namespace Udemy.Skinet.Infrastructure.Identity {
    public class AppIdentityDbContext : IdentityDbContext<AppUser> {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }
    }
}
