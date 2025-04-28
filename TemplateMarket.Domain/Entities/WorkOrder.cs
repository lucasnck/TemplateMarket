using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;


public class WorkOrder : BaseEntity
{
    public long OrderItemServiceId { get; set; }
    public virtual OrderItemService OrderItemService { get; set; }
    public long? AssignedToPartnerId { get; set; }
    public virtual Partner? AssignedToPartner { get; set; }
    public string Status { get; set; }
    public DateTime? FinishedDate { get; private set; }
}
