using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class ProcessorStep : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public long WorkflowId { get; set; }
    public virtual Workflow Workflow { get; set; }

    public virtual ICollection<Processor> Processors { get; set; }

    public bool IsDefault { get; set; }
}