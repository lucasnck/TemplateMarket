using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Customers;

public class CreateCustomerOnUserCompanyCreatedDomainEventHandler(
    IRepository _repo
) : INotificationHandler<CompanyCreatedDomainEvent>
{
    public async Task Handle(CompanyCreatedDomainEvent notification, CancellationToken ct)
    {
        var company = await _repo.SingleOrThrow<Company>(x => x.Id == notification.company.Id);

        var customer = new Customer
        {
            Company = company,
            Entity = company.Entity,
            Name = company.Entity.Name,
            Email = company.Email,
            Phone = company.Phone,
        };

        await _repo.AddAsync(customer);
    }
}
