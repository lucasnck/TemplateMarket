using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class WorkflowItem : BaseEntity
{
    public long? WorkOrderId { get; set; }
    public virtual WorkOrder? WorkItem { get; set; }

    public long? OrderId { get; set; }
    public virtual Order? Order { get; set; }

    public long? Productd { get; set; }
    public virtual Product? Product { get; set; }

    public virtual ICollection<WorkflowItemProcessorStep> WorkflowItemProcessorSteps { get; set; }
}
