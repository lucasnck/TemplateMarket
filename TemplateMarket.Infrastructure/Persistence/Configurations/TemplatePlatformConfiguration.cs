using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class TemplatePlatformConfiguration : IEntityTypeConfiguration<TemplatePlatform>
{
    public void Configure(EntityTypeBuilder<TemplatePlatform> builder)
    {
        builder.HasKey(tp => new { tp.TemplateId, tp.PlatformId });

        builder.HasOne(tp => tp.Template)
            .WithMany(t => t.TemplatePlatforms)
            .HasForeignKey(tp => tp.TemplateId);

        builder.HasOne(tp => tp.Platform)
            .WithMany(p => p.TemplatePlatforms)
            .HasForeignKey(tp => tp.PlatformId);
    }
}
