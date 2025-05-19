using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Roles.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Roles.Commands;

public class CreateRoleCommand : RoleDto, IRequest<long>
{
}

public class CreateRoleCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<CreateRoleCommand, long>
{
    public async Task<long> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = _repo.Query<Role>().FirstOrDefault(r => r.Name == request.Name);
        if (entity != null) throw new AlreadExistsException(request.Name);

        entity = _mapper.Map<Role>(request);

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}
