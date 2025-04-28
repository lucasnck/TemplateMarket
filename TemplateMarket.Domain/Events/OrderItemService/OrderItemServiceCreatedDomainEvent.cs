using MediatR;

namespace TemplateMarket.Domain.Events;

public class OrderItemServiceCreatedDomainEvent(long id) : INotification
{
    public long Id { get; } = id;
}
