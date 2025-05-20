using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class GroupTemplate : BaseEntity
{
    public string TemplateKey { get; set; }
    public virtual ICollection<Group> Groups { get; set; }
}
