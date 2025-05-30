using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string SKU { get; private set; }
    public bool IsActive { get; private set; } = true;

    public virtual ICollection<Stock> Stocks { get; set; } = [];

    public virtual ICollection<Price> Prices { get; set; } = [];

    public virtual ICollection<File> Images { get; set; } = [];

    public long PartnerId { get; private set; }
    public virtual Partner Partner { get; private set; }

    public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    private Product() { }
}
