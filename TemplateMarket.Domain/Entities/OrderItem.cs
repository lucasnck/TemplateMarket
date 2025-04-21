namespace TemplateMarket.Domain.Entities;

public enum ProductType { Template, Service }

public class OrderItem : BaseEntity
{
    public long OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
    public virtual ProductType Type { get; set; }
    public long ProductId { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public virtual Commission? Commission { get; set; }
    public virtual WorkOrder? WorkOrder { get; set; }
}
