using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(x => x.Product)
           .WithOne()
           .HasForeignKey<ProductCategory>(x => x.ProductId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Category)
           .WithOne()
           .HasForeignKey<ProductCategory>(x => x.CategoryId)
           .OnDelete(DeleteBehavior.Cascade);

    }
}