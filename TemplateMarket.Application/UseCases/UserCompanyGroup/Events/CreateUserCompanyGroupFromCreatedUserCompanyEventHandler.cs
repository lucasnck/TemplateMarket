using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events.OrderItem;

namespace TemplateMarket.Application.UseCases.UserCompanies.EventHandlers;

public class CreateUserCompanyGroupFromCreatedUserCompanyEventHandler(
    IRepository _repo
) : INotificationHandler<UserCompanyOwnerCreatedDomainEvent>
{
    public async Task Handle(UserCompanyOwnerCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var userCompany = (await _repo.SingleOrThrow<UserCompany>(uc => uc.Id == notification.Id));

        if (userCompany.Company.Owner.Id != userCompany.User.Id)
            return;

        var templateKey = "UserComapnyGroupOwner";

        var templates = _repo.Query<UserGroupTemplate>()
            .Where(ugt => ugt.TemplateKey == templateKey)
            .ToList();

        foreach (var template in templates)
        {
            var userCompanyGroup = new UserCompanyGroup()
            {
                UserCompany = userCompany,
                Group = template.Group,
            };

            await _repo.AddAsync(userCompanyGroup);
        }

        await _repo.SaveChangesAsync();
    }
}
