using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class ProcessorOutputConfiguration : IEntityTypeConfiguration<ProcessorOutput>
    {
        public void Configure(EntityTypeBuilder<ProcessorOutput> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}