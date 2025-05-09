using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Customers.Events;

public class CreateCustomerOnUserCreatedDomainEventHandler(
    IRepository _repo
) : INotificationHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken ct)
    {
        var user = await _repo.SingleOrThrow<User>(x => x.Id == notification.User.Id);

        var customer = new Customer
        {
            User = user,
            Name = user.Entity.Name,
            Email = user.Email,
            Phone = user.Phone,
            Entity = user.Entity,
        };

        await _repo.AddAsync(customer);
        await _repo.SaveChangesAsync();
    }
}
