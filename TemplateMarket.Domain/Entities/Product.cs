using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public string SKU { get; private set; }
    public int? StockQuantity { get; private set; }
    public bool IsActive { get; private set; } = true;

    public ProductType ProductType { get; private set; }

    public long PartnerId { get; private set; }
    public Partner Partner { get; private set; }

    private Product() { }

    public Product(string name, string sku, ProductType productType, decimal price, long partnerId, string? description = null, int? stockQuantity = null)
    {
        Name = name;
        SKU = sku;
        ProductType = productType;
        Price = price;
        PartnerId = partnerId;
        Description = description;
        StockQuantity = stockQuantity;
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
