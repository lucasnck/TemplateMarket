using MediatR;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Domain.Events;

public class UserCompanyCreatedDomainEvent(UserCompany userCompany) : INotification
{
    public UserCompany UserCompany { get; } = userCompany;
}
