using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Commission : BaseEntity
{
    public long PartnerId { get; set; }
    public virtual Partner Partner { get; set; } = default!;
    public long? OrderItemServiceId { get; set; }
    public virtual OrderItemService? OrderItemService { get; set; }
    public long? OrderItemId { get; set; }
    public virtual OrderItem? OrderItem { get; set; }
    
    public decimal SaleAmount { get; set; }
    public decimal CommissionAmount { get; set; }
    public string Status { get; set; }
}
