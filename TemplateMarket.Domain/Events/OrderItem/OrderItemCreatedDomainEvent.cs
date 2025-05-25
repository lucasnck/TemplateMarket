using MediatR;

namespace TemplateMarket.Domain.Events;

public class OrderItemCreatedDomainEvent(long Id) : INotification
{
    public long Id { get; } = Id;
}
