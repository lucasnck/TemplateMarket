using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class UserCompanyGroup : BaseEntity
{
    public long UserId { get; set; }
    public virtual User User { get; set; }

    public long CompanyId { get; set; }
    public virtual Company Company { get; set; }

    public long GroupId { get; set; }
    public virtual Group Group { get; set; }
}
