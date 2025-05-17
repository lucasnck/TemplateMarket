using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class UserCompanyGroup : BaseEntity
{
    public long UserCompanyId { get; set; }
    public virtual UserCompany UserCompany { get; set; }

    public long GroupId { get; set; }
    public virtual Group Group { get; set; }
}
