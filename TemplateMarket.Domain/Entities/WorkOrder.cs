using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;


public class WorkOrder : BaseEntity
{
    public long OrderItemId { get; set; }
    public virtual OrderItem OrderItem { get; set; } = default!;
    public long? AssignedToPartnerId { get; set; }
    public virtual Partner? AssignedToPartner { get; set; }
    public string Status { get; set; }
}
