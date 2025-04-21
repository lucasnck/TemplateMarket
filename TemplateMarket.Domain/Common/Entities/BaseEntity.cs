namespace TemplateMarket.Domain.Common.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
