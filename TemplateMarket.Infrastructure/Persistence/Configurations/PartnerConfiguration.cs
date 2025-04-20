using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Type)
                .IsRequired();
        }
    }
}
