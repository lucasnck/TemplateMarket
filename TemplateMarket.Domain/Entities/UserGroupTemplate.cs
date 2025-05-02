using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class UserGroupTemplate : BaseEntity
{
    public string TemplateKey { get; set; } = default!;
    public long GroupId { get; set; }
    public virtual Group Group { get; set; }
}
