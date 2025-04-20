using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Type)
                .IsRequired();

            builder.Property(oi => oi.Name)
                .IsRequired();

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.Items)
                   .HasForeignKey(oi => oi.OrderId);
        }
    }
}
