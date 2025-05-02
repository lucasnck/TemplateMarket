using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class GroupRole : BaseEntity
{
    public long GroupId { get; set; }
    public virtual Group Group { get; set; }

    public long RoleId { get; set; }
    public virtual Role Role { get; set; }
}
