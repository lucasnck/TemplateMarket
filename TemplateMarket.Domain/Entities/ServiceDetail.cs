using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class ServiceDetail : BaseEntity
{
    public long ProductId { get; private set; }
    public virtual Product Product { get; private set; }
    public int EstimatedDeliveryDays { get; private set; }
    public string? SupportType { get; private set; }

    private ServiceDetail() { }

    public ServiceDetail(long productId, int estimatedDeliveryDays, string? supportType = null)
    {
        ProductId = productId;
        EstimatedDeliveryDays = estimatedDeliveryDays;
        SupportType = supportType;
    }
}
