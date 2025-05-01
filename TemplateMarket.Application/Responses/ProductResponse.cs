using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Application.Responses;


public class ProductResponse
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string SKU { get; private set; }
    public int? StockQuantity { get; private set; }

    // prices
    //public virtual ICollection<Price> Prices { get; set; }

    // images
    //public virtual ICollection<Image> Images { get; set; }

    public ProductType ProductType { get; private set; }

    public IEnumerable<PlatformResponse> Platforms { get; set; }
    public IEnumerable<CategoryResponse> Categories { get; set; }
}
