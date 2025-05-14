using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class WorkflowItemProcessorStepConfiguration : IEntityTypeConfiguration<WorkflowItemProcessorStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowItemProcessorStep> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.WorkflowItem)
                .WithMany(w => w.WorkflowItemProcessorSteps)
                .HasForeignKey(p => p.WorkflowItemId);

        }
    }
}