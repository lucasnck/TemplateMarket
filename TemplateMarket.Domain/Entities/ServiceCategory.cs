namespace TemplateMarket.Domain.Entities;

public class ServiceCategory : BaseEntity
{
    public long ServiceId { get; set; }
    public Service Service { get; set; } = default!;
    public long CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
