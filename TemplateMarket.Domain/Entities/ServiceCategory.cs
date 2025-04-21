using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class ServiceCategory : BaseEntity
{
    public long ServiceId { get; set; }
    public virtual Service Service { get; set; } = default!;
    public long CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;
}
