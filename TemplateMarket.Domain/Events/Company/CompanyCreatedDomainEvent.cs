namespace TemplateMarket.Domain.Events;

public class CompanyCreatedDomainEvent(long id) : DomainEvent
{
    public long Id { get; } = id;
}
