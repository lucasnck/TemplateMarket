namespace TemplateMarket.Domain.Entities;


public class WorkOrder : BaseEntity
{
    public long OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; } = default!;
    public long? AssignedToPartnerId { get; set; }
    public Partner? AssignedToPartner { get; set; }
    public string Status { get; set; }
}
