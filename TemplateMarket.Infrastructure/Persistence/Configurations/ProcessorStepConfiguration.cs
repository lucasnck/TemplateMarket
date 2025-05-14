using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class ProcessorStepConfiguration : IEntityTypeConfiguration<ProcessorStep>
    {
        public void Configure(EntityTypeBuilder<ProcessorStep> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}