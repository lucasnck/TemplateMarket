using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;

namespace TemplateMarket.Domain.Entities
{
    public class TemplateDetail : BaseEntity
    {
        public string Theme { get; set; }
        public string PreviewUrl { get; set; } = default!;

        public long ProductId { get; private set; }
        public virtual Product Product { get; private set; }
    }
}
