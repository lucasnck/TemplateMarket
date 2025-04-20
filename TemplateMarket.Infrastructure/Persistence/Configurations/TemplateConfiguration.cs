using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasMaxLength(1000);

        builder.Property(t => t.Price)
            .HasColumnType("decimal(10,2)");

        builder.Property(t => t.PreviewUrl).HasMaxLength(300);
        builder.Property(t => t.ThumbnailUrl).HasMaxLength(300);

        builder.Property(t => t.CreatedAt)
            .HasDefaultValueSql("NOW()");
    }
}
