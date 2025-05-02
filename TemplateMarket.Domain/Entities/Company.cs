using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Company : BaseEntity
{
    public long EntityId { get; private set; }
    public virtual Entity Entity { get; private set; }

    public long OwnerUserId { get; private set; }
    public virtual User Owner { get; private set; }

    public virtual ICollection<UserCompanyGroup> UserCompanyGroups { get; set; }

    private Company() { }

    public Company(long entityId, long ownerUserId)
    {
        EntityId = entityId;
        OwnerUserId = ownerUserId;
    }
}
