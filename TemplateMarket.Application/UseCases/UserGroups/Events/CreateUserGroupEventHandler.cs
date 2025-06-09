using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Integration;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.UserGroups.Events;

public class CreateUserGroupEventHandler(
    IRepository _repo,
    IGroupTemplateService _groupTemplateService,
    ILogger<UserCreateConfirmationTokenEventHandler> _logger
) : IDomainEventHandler<UserCreatedDomainEvent>
{
    private IImmutableList<string> templateKeys = ImmutableList.Create("base:user", "base:user-customer");

    public async Task HandleAsync(UserCreatedDomainEvent @event)
    {
        _logger.LogInformation($"Criando grupo de usuário para o UserId:{@event.UserId}");

        var user = await _repo.SingleOrThrow<User>(x => x.Id == @event.UserId);

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