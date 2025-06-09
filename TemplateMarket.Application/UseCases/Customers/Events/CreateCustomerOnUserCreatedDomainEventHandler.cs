using MediatR;
using Microsoft.Extensions.Logging;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Integration;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Customers.Events;

public class CreateCustomerOnUserCreatedDomainEventHandler(
    IRepository _repo,
    ILogger<UserCreateConfirmationTokenEventHandler> _logger
) : IDomainEventHandler<UserCreatedDomainEvent>
{
    public async Task HandleAsync(UserCreatedDomainEvent @event)
    {
        _logger.LogInformation($"Criando o customer para o UserId:{@event.UserId}");

        var user = await _repo.SingleOrThrow<User>(x => x.Id == @event.UserId);

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
