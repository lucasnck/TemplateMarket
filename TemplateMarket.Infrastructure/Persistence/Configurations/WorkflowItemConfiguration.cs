using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class WorkflowItemConfiguration : IEntityTypeConfiguration<WorkflowItem>
    {
        public void Configure(EntityTypeBuilder<WorkflowItem> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.HasMany(w => w.WorkflowItemProcessorSteps)
                   .WithOne(wips => wips.WorkflowItem)
                   .HasForeignKey(wips => wips.Id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}