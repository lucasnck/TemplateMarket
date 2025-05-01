using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class ShowcaseProductConfiguration : IEntityTypeConfiguration<ShowcaseProduct>
{
    public void Configure(EntityTypeBuilder<ShowcaseProduct> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Showcase)
            .WithMany(x => x.ShowcaseProducts)
            .HasForeignKey(x => x.ShowcaseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
