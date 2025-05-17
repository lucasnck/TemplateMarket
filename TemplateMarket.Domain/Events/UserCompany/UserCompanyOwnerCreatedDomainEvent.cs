using MediatR;

namespace TemplateMarket.Domain.Events.OrderItem;

public class UserCompanyOwnerCreatedDomainEvent(long id) : INotification
{
    public long Id { get; } = id;
}
