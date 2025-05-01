using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class ServiceDetailConfiguration : IEntityTypeConfiguration<ServiceDetail>
{
    public void Configure(EntityTypeBuilder<ServiceDetail> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(x => x.Product)
            .WithOne()
            .HasForeignKey<ServiceDetail>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
