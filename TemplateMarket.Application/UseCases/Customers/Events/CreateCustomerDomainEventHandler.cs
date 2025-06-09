using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Integration;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Customers;

public class CreateCustomerDomainEventHandler(
    IRepository _repo
) : IDomainEventHandler<CompanyCreatedDomainEvent>
{
    public async Task HandleAsync(CompanyCreatedDomainEvent @event)
    {
        var company = await _repo.SingleOrThrow<Company>(x => x.Id == @event.Id);

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
