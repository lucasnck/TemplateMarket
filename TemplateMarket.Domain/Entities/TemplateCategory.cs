namespace TemplateMarket.Domain.Entities;

public class TemplateCategory : BaseEntity
{
    public long TemplateId { get; set; }
    public Template Template { get; set; } = default!;
    public long CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
