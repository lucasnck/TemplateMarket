using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class OrderItem : BaseEntity
{
    public long OrderId { get; set; }
    public virtual Order Order { get; set; }

    public long? TemplateId { get; set; }
    public virtual Template? Template { get; set; }
    public long? ServiceId { get; set; }
    public virtual Service? Service { get; set; }

    public int Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public virtual List<OrderItemService> Services { get; private set; } = [];

    private OrderItem() { }

    public OrderItem(long templateId, decimal price)
    {
        TemplateId = templateId;
        UnitPrice = price;
    }

    public OrderItem(long serviceId, decimal price, bool isAvulso)
    {
        ServiceId = serviceId;
        UnitPrice = price;
    }

    public void AddService(long serviceId, decimal price)
    {
        Services.Add(new OrderItemService(serviceId, price));
    }
}
