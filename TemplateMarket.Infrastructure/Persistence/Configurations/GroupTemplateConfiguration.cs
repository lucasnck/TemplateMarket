using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations;

public class GroupTemplateConfiguration : IEntityTypeConfiguration<GroupTemplate>
{
    public void Configure(EntityTypeBuilder<GroupTemplate> builder)
    {
        builder.HasKey(ugt => ugt.Id);
    }
}
