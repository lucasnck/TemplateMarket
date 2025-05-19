using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.UserGroups.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.UserGroups.Commands;

public class UpdateUserGroupCommand : UserGroupDto, IRequest<long>
{
}

public class UpdateUserGroupCommandHandler(
    IRepository _repo
) : IRequestHandler<UpdateUserGroupCommand, long>
{
    public async Task<long> Handle(UpdateUserGroupCommand request, CancellationToken cancellationToken)
    {
        var user = await _repo.SingleOrThrow<User>(u => u.Id == request.UserId);

        var groups = _repo.Query<Group>().Where(g => request.GroupIds.Contains(g.Id));

        var currentGroupIds = user.UserGroups?.Select(ug => ug.GroupId).ToList() ?? [];

        var groupsToAdd = groups
            .Where(g => !currentGroupIds.Contains(g.Id))
            .ToList();

        foreach (var group in groupsToAdd)
        {
            var userGroup = new UserGroup()
            {
                Group = group,
                User = user,
            };

            await _repo.AddAsync(userGroup);
        }

        var userGroupsToRemove = user.UserGroups?
            .Where(ug => !request.GroupIds.Contains(ug.GroupId))
            .ToList() ?? [];

        foreach (var userGroups in userGroupsToRemove)
        {
            _repo.Remove(userGroups);
        }

        await _repo.UpdateAsync(user);
        await _repo.SaveChangesAsync();

        return user.Id;
    }
}
