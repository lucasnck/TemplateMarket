using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class UserCompany : BaseEntity
{
    public bool IsActive { get; set; }

    public long UserId  { get; set; }
    public virtual User User { get; set; }

    public long CompanyId { get; set; }
    public virtual Company Company { get; set; }

    public virtual ICollection<UserCompanyGroup> UserCompanyGroups { get; set; }
}
