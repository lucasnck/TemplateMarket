using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class ProductCategory : BaseEntity
{
    public long ProductId { get; private set; }
    public virtual Product Product { get; private set; }

    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public ProductCategory() { }
}
