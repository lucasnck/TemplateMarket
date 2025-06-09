namespace TemplateMarket.Application.Common.Integration;

public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent integrationEvent);
}
