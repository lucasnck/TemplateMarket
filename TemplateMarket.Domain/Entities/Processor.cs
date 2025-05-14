using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Processor : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string CommandName { get; set; }

    public bool IsDefault {  get; set; }
    
    public virtual ICollection<ProcessorOutput> ProcessorOutputs { get; set; }
    public virtual ICollection<ProcessorStep> ProcessorSteps { get; set; }
}
