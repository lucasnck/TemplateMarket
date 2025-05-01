using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class TemplateDetailConfiguration : IEntityTypeConfiguration<TemplateDetail>
{
    public void Configure(EntityTypeBuilder<TemplateDetail> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(x => x.Product)
           .WithOne()
           .HasForeignKey<TemplateDetail>(x => x.ProductId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
