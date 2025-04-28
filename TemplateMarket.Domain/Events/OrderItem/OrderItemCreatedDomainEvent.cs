using MediatR;

namespace TemplateMarket.Domain.Events.OrderItem;

public class OrderItemCreatedDomainEvent(long Id) : INotification
{
    public long Id { get; } = Id;
}
