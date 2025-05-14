using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class WorkflowItemProcessorStep : BaseEntity
{
    public long WorkflowItemId { get; set; }
    public virtual WorkflowItem WorkflowItem { get; set; }

    public virtual ICollection<WorkflowItemProcessor> WorkflowItemProcessors { get; set; }
}
