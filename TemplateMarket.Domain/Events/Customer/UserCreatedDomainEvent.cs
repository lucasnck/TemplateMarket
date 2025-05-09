using MediatR;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Domain.Events;

public record UserCreatedDomainEvent(User User) : INotification;
