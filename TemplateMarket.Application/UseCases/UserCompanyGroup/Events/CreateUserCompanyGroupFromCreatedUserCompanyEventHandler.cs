using MediatR;
using System.Collections.Immutable;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.UserCompanies.EventHandlers;

public class CreateUserCompanyGroupFromCreatedUserCompanyEventHandler(
    IRepository _repo,
    IGroupTemplateService _groupTemplateService
) : INotificationHandler<UserCompanyCreatedDomainEvent>
{
    private List<string> TemplateKeys = new List<string>() { "base:user-company" };

    public async Task Handle(UserCompanyCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var userCompany = (await _repo.SingleOrThrow<UserCompany>(uc => uc.Id == notification.UserCompany.Id));

        if (userCompany.Company.Owner.Id == userCompany.User.Id)
            TemplateKeys.Add("owner:user-company");

        var groupIds = _groupTemplateService.GetGroupIdsForTemplates(TemplateKeys);

        foreach (var groupId in groupIds)
        {
            var userCompanyGroup = new TemplateMarket.Domain.Entities.UserCompanyGroup()
            {
                UserCompany = userCompany,
                GroupId = groupId,
            };

            await _repo.AddAsync(userCompanyGroup);
        }
    }
}
