using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class CommissionConfiguration : IEntityTypeConfiguration<Commission>
    {
        public void Configure(EntityTypeBuilder<Commission> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status)
                .IsRequired();

            builder.HasOne(c => c.Partner)
                   .WithMany(p => p.Commissions)
                   .HasForeignKey(c => c.PartnerId);

            builder.HasOne(c => c.OrderItem)
                   .WithOne(oi => oi.Commission)
                   .HasForeignKey<Commission>(c => c.OrderItemId);
        }
    }
}
