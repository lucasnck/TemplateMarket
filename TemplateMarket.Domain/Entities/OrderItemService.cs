using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class OrderItemService : BaseEntity
{
    public long OrderItemId { get; set; }
    public virtual OrderItem OrderItem { get; set; }

    public long ServiceId { get; set; }
    public virtual Service Service { get; set; }

    public long? PartnerId { get; set; }
    public virtual Partner Partner { get; set; }
    public decimal UnitPrice { get; set; }

    public long WorkOrderId { get; set; }
    public virtual WorkOrder WorkOrder { get; set; }

    private OrderItemService() { }

    public OrderItemService(long serviceId, decimal price)
    {
        ServiceId = serviceId;
        UnitPrice = price;
    }
}
