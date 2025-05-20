using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events.OrderItem;

namespace TemplateMarket.Application.UseCases.UserCompanies.EventHandlers;

public class CreateUserCompanyGroupFromCreatedUserCompanyEventHandler(
    IRepository _repo,
    IGroupTemplateService _groupTemplateService
) : INotificationHandler<UserCompanyOwnerCreatedDomainEvent>
{
    public async Task Handle(UserCompanyOwnerCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var userCompany = (await _repo.SingleOrThrow<UserCompany>(uc => uc.Id == notification.Id));

        if (userCompany.Company.Owner.Id != userCompany.User.Id)
            return;

        var templateKey = "UserComapnyGroupOwner";

        var groupIds = _groupTemplateService.GetGroupIdsForTemplateAsync(templateKey);

        foreach (var groupId in groupIds)
        {
            var userCompanyGroup = new TemplateMarket.Domain.Entities.UserCompanyGroup()
            {
                UserCompany = userCompany,
                GroupId = groupId,
            };

            await _repo.AddAsync(userCompanyGroup);
        }

        await _repo.SaveChangesAsync();
    }
}
