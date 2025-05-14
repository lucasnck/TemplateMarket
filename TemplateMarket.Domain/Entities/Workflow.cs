using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Workflow : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ProcessorStep> ProcessorSteps { get; set; }

    public virtual ICollection<WorkflowItem> WorkflowItems { get; set; }
    public virtual ICollection<WorkflowStatus> WorkflowStatus { get; set; }
}
