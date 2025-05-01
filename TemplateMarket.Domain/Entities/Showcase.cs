using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Showcase : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public long? CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public virtual ICollection<ShowcaseProduct> ShowcaseProducts { get; private set; } = new List<ShowcaseProduct>();
}
