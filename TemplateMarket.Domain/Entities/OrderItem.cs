namespace TemplateMarket.Domain.Entities;

public enum ProductType { Template, Service }

public class OrderItem : BaseEntity
{
    public long OrderId { get; set; }
    public Order Order { get; set; } = default!;
    public ProductType Type { get; set; }
    public long ProductId { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public Commission? Commission { get; set; }
    public WorkOrder? WorkOrder { get; set; }
}
