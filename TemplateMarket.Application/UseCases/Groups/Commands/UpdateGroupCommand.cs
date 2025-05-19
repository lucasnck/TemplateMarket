using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.Common.Exceptions;
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

        entity = _mapper.Map<Group>(request);
        var roles = _repo.Query<Role>().Where(r => request.RoleIds.Contains(r.Id))
            .ToList();

        foreach (var role in roles)
        {
            var groupRole = new GroupRole()
            {
                Group = entity,
                Role = role,
            };

            await _repo.AddAsync(groupRole);
        }

        await _repo.UpdateAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}

