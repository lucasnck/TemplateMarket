namespace TemplateMarket.Domain.Events;

public class UserCompanyCreatedDomainEvent(long id) : DomainEvent
{
    public long Id { get; } = id;
}
