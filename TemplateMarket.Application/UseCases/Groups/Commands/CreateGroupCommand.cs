using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Groups.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Groups.Commands;

public class CreateGroupCommand : GroupDto, IRequest<long>
{
}

public class CreateGroupCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<CreateGroupCommand, long>
{
    public async Task<long> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = _repo.Query<Group>().FirstOrDefault(g => g.Name == request.Name);
        if (entity != null) throw new AlreadExistsException(request.Name);

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

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return  entity.Id;
    }
}
