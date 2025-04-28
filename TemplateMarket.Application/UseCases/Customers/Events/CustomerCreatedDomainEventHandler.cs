using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Customers.Events;

public class CustomerCreatedDomainEventHandler(IRepository<Customer> _repository)
    : INotificationHandler<CustomerCreatedDomainEvent>
{
    public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken ct)
    {
        var customer = new Customer
        {
            UserId = notification.UserId
        };

        await _repository.AddAsync(customer);
        await _repository.SaveChangesAsync();
    }
}
