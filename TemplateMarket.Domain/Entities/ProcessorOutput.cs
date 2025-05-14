using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class ProcessorOutput : BaseEntity
{
    public bool IsFinal { get; set; }

    public long? ConnectedProcessorId { get; set; }
    public virtual Processor? ConnectedProcessor {  get; set; }  
}
