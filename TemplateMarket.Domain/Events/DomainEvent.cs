using TemplateMarket.Application.Common.Integration;

namespace TemplateMarket.Domain.Events;

public class DomainEvent : IDomainEvent
{
    public Guid EventId => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.Now;
}
