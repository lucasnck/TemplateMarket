using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class FileConfiguration : IEntityTypeConfiguration<TemplateMarket.Domain.Entities.File>
{
    public void Configure(EntityTypeBuilder<TemplateMarket.Domain.Entities.File> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(k => k.Key)
            .IsUnique();
    }
}