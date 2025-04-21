namespace TemplateMarket.Domain.Entities;

public class TemplateCategory : BaseEntity
{
    public long TemplateId { get; set; }
    public virtual Template Template { get; set; } = default!;
    public long CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;
}
