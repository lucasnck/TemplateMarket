using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class WorkflowItemProcessorConfiguration : IEntityTypeConfiguration<WorkflowItemProcessor>
    {
        public void Configure(EntityTypeBuilder<WorkflowItemProcessor> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.WorkflowItem)
                .WithMany()
                .HasForeignKey(p => p.Id);

            builder.HasOne(p => p.ProcessorOutput)
                .WithMany()
                .HasForeignKey(p => p.Id);

            builder.HasOne(p => p.Processor)
                .WithMany()
                .HasForeignKey(p => p.Id);
        }
    }
}