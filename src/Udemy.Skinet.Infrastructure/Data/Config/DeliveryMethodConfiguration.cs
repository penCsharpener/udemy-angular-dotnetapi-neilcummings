using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Skinet.Core.Entities.OrderAggregate;

namespace Udemy.Skinet.Infrastructure.Data.Config {
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod> {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder) {
            builder.Property(d => d.Price).HasColumnType("decimal(18,2)");
        }
    }
}
