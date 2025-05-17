using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Company : BaseEntity
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public long EntityId { get; set; }
    public virtual Entity Entity { get; set; }

    public long OwnerUserId { get; set; }
    public virtual User Owner { get; set; }

    public virtual ICollection<UserCompany> UserCompanies { get; set; }

    public virtual ICollection<UserCompanyGroup> UserCompanyGroups { get; set; }

    public Company() { }
}
