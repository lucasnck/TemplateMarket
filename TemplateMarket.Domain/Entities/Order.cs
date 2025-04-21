using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Order : BaseEntity
{
    public long CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = default!;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }

    public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
