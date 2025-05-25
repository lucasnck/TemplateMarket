using MediatR;
using System.Collections.Immutable;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.UserGroups.Events;

public class CreateUserGroupFromCreatedUserEventHandler(
    IRepository _repo,
    IGroupTemplateService _groupTemplateService
) : INotificationHandler<UserCreatedDomainEvent>
{
    private IImmutableList<string> templateKeys = ImmutableList.Create("base:user", "base:user-customer");

    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var user = await _repo.SingleOrThrow<User>(x => x.Id == notification.User.Id);

        var groupIds = _groupTemplateService.GetGroupIdsForTemplates(templateKeys);

        foreach (var groupId in groupIds)
        {
            var userGroup = new UserGroup()
            {
                GroupId = groupId,
                User = user,
            };

            await _repo.AddAsync(userGroup);
        }

        await _repo.SaveChangesAsync();
    }
}