using MediatR;

namespace TemplateMarket.Domain.Events;

public class CustomerCreatedDomainEvent(long userId) : INotification
{
    public long UserId { get; } = userId;
}
