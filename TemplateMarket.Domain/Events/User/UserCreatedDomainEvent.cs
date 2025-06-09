namespace TemplateMarket.Domain.Events;

public class UserCreatedDomainEvent(long userId) : DomainEvent
{
    public long UserId { get; } = userId;
}