using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class WorkflowConfiguration : IEntityTypeConfiguration<Workflow>
    {
        public void Configure(EntityTypeBuilder<Workflow> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(w => w.ProcessorSteps)
                   .WithOne()
                   .HasForeignKey(s => s.WorkflowId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}