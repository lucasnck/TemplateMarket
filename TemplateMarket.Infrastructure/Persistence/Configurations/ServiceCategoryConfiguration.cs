using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(sc => new { sc.ServiceId, sc.CategoryId });

            builder.HasOne(sc => sc.Service)
                   .WithMany(s => s.ServiceCategories)
                   .HasForeignKey(sc => sc.ServiceId);

            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.ServiceCategories)
                   .HasForeignKey(sc => sc.CategoryId);
        }
    }
}
