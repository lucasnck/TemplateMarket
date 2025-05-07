using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Platforms.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Commands;

public class CreatePlatformCommand : CreatePlatformDto, IRequest<long>
{
}

public class CreatePlatformCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<CreatePlatformCommand, long>
{
    public async Task<long> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        var exists = _repo.Query<Platform>().Any(p => p.Name == request.Name);
        if (exists)
            throw new AlreadExistsException(nameof(Platform));

        var entity = _mapper.Map<Platform>(request);

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}
