using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Integration;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Common.Constants.GroupTemplates;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.UserCompanies.EventHandlers;

public class CreateUserCompanyGroupEventHandler(
    IRepository _repo,
    IGroupTemplateService _groupTemplateService
) : IDomainEventHandler<UserCompanyCreatedDomainEvent>
{
    private List<string> TemplateKeys = new List<string>()
    { 
        GroupTemplatesConstants.Templates.BASE_USER_COMPANY 
    };

    public async Task HandleAsync(UserCompanyCreatedDomainEvent @event)
    {
        var userCompany = (await _repo.SingleOrThrow<UserCompany>(uc => uc.Id == @event.Id));

        if (userCompany.Company.Owner.Id == userCompany.User.Id)
            TemplateKeys.Add(GroupTemplatesConstants.Templates.USER_COMPANY_OWNER);

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
