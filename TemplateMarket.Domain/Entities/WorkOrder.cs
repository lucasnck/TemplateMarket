using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class WorkOrder : BaseEntity
{
    public long? OrderItemId { get; set; }
    public virtual OrderItem? OrderItem { get; set; }

    public long? OrderItemServiceId { get; set; }
    public virtual OrderItemService? OrderItemService { get; set; }

    public long? AssignedToUserId { get; set; }
    public virtual User? AssignedToUser { get; set; }

    public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Pending;
    public DateTime? StartedDate { get; set; }
    public DateTime? CompletedDate { get; set; }

    private WorkOrder() { }

    public WorkOrder(long? orderItemId = null, long? orderItemServiceId = null)
    {
        if (orderItemId == null && orderItemServiceId == null)
            throw new ArgumentException("A WorkOrder must be associated with either an OrderItem or an OrderItemService.");

        OrderItemId = orderItemId;
        OrderItemServiceId = orderItemServiceId;
        Status = WorkOrderStatus.Pending;
    }

    public void AssignTo(long userId)
    {
        AssignedToUserId = userId;
        Status = WorkOrderStatus.Assigned;
    }
}
