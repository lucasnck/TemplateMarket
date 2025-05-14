using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class ProcessorConfiguration : IEntityTypeConfiguration<Processor>
    {
        public void Configure(EntityTypeBuilder<Processor> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(p => p.CommandName)
                .IsUnique();

            builder.HasMany(p => p.ProcessorOutputs)
                   .WithOne()
                   .HasForeignKey(o => o.ConnectedProcessorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}