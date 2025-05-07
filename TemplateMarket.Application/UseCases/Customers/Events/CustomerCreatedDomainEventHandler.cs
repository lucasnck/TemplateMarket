using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Customers.Events;

public class CustomerCreatedDomainEventHandler(
    IRepository _repo
) : INotificationHandler<CustomerCreatedDomainEvent>
{
    public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken ct)
    {
        var customer = new Customer
        {
            UserId = notification.UserId
        };

        await _repo.AddAsync(customer);
        await _repo.SaveChangesAsync();
    }
}
