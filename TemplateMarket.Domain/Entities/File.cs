using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class File : BaseEntity
{
    public string Location { get; set; }
    public string Key { get; set; }
}
