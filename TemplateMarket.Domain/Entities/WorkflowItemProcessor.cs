using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class WorkflowItemProcessor : BaseEntity
{
    public long WorkflowItemId { get; set; }
    public virtual WorkflowItem WorkflowItem { get; set; }

    public long ProcessorOutputId { get; set; }
    public virtual ProcessorOutput ProcessorOutput { get; set; }
    
    public long ProcessorId { get; set; }
    public virtual Processor Processor { get; set; }
}
