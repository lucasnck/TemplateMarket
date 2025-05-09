using MediatR;

namespace TemplateMarket.Domain.Events;

public class UserResetTokenDomainEvent(long id) : INotification
{
    public long Id { get; } = id;
}
