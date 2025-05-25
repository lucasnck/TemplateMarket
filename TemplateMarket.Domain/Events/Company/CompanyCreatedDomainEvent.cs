using MediatR;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Domain.Events;

public record CompanyCreatedDomainEvent(Company company) : INotification;
