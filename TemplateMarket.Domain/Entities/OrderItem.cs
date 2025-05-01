using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class OrderItem : BaseEntity
{
    public long OrderId { get; set; }
    public virtual Order Order { get; set; }

    public long ProductId { get; private set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }

    public virtual ICollection<OrderItemService> OrderItemServices { get; private set; } = new List<OrderItemService>();

    public OrderItem() { }
}
