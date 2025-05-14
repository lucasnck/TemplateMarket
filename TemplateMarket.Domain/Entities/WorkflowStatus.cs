using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class WorkflowStatus : BaseEntity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Icon { get; set; }

    public virtual ICollection<WorkflowView> WorkflowViews { get; set; }

    public long ProcessorStepId { get; set; }
    public virtual ProcessorStep ProcessorStep { get; set; }
}
