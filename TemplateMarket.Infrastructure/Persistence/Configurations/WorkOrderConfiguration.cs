using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Configurations
{
    public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Status)
                .IsRequired();

            builder.HasOne(w => w.OrderItem)
                   .WithOne(oi => oi.WorkOrder)
                   .HasForeignKey<WorkOrder>(w => w.OrderItemId);

            builder.HasOne(w => w.AssignedToPartner)
                   .WithMany(p => p.WorkOrders)
                   .HasForeignKey(w => w.AssignedToPartnerId);
        }
    }
}
