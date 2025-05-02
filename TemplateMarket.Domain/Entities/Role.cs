using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public virtual ICollection<GroupRole> GroupRoles { get; set; }
}
