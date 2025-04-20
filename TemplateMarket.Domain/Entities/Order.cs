namespace TemplateMarket.Domain.Entities;

public class Order : BaseEntity
{
    public long CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
