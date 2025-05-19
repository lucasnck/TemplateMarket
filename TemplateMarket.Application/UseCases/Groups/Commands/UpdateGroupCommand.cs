using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Groups.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Groups.Commands;

public class UpdateGroupCommand : UpdateGroupDto, IRequest<long>
{
}

public class UpdateGroupCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<UpdateGroupCommand, long>
{
    public async Task<long> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.SingleOrThrow<Group>(g => g.Id == request.Id);

        _mapper.Map(request, entity);

        var roles = _repo.Query<Role>().Where(r => request.RoleIds.Contains(r.Id))
            .ToList();

        var currentRoleIds = entity.GroupRoles?.Select(gr => gr.RoleId).ToList() ?? [];

        // Identifica roles a adicionar
        var rolesToAdd = roles
            .Where(r => !currentRoleIds.Contains(r.Id))
            .ToList();

        foreach (var role in rolesToAdd)
        {
            var groupRole = new GroupRole()
            {
                Group = entity,
                Role = role,
            };

            await _repo.AddAsync(groupRole);
        }

        var rolesToRemove = entity.GroupRoles?
            .Where(gr => !request.RoleIds.Contains(gr.RoleId))
            .ToList() ?? [];

        foreach (var groupRole in rolesToRemove)
        {
            _repo.Remove(groupRole);
        }

        await _repo.UpdateAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}

