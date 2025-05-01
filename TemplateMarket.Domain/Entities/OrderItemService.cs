using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class OrderItemService : BaseEntity
{
    public long OrderItemId { get; private set; }
    public virtual OrderItem OrderItem { get; set; }

    public long ProductId { get; private set; }
    public virtual Product Product { get; set; }

    public long PartnerId { get; private set; }
    public virtual Partner Partner { get; set; }

    public decimal UnitPrice { get; private set; }

    public OrderItemService() { }
}
