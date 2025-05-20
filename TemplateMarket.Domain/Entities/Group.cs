using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public virtual ICollection<GroupRole> GroupRoles { get; set; }
    public virtual ICollection<GroupTemplate> GroupTemplates { get; set; }
}
