using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class TemplateCategoryConfiguration : IEntityTypeConfiguration<TemplateCategory>
    {
        public void Configure(EntityTypeBuilder<TemplateCategory> builder)
        {
            builder.HasKey(tc => new { tc.TemplateId, tc.CategoryId });

            builder.HasOne(tc => tc.Template)
                   .WithMany(t => t.TemplateCategories)
                   .HasForeignKey(tc => tc.TemplateId);

            builder.HasOne(tc => tc.Category)
                   .WithMany(c => c.TemplateCategories)
                   .HasForeignKey(tc => tc.CategoryId);
        }
    }
}
