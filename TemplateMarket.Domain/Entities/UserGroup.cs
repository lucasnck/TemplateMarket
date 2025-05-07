using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class UserGroup : BaseEntity
{
    public long UserId { get; set; }
    public virtual User User { get; set; }

    public long GroupId { get; set; }
    public virtual Group Group { get; set; }

    public virtual ICollection<GroupRole> Roles { get; set; }
}
