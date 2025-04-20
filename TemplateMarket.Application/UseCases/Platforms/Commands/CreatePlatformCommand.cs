using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Platforms.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Commands;

public class CreatePlatformCommand : IRequest<Guid>
{
    public CreatePlatformDto PlatformDto { get; set; }
}

public class CreatePlatformCommandHandler(IRepository<Platform> _repository)
    : IRequestHandler<CreatePlatformCommand, Guid>
{
    public async Task<Guid> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        var exists = (await _repository.FindAsync(p => p.Name == request.PlatformDto.Name)).Any();
        if (exists)
            throw new AlreadExistsException(nameof(Platform));

        var entity = new Platform
        {
            Name = request.PlatformDto.Name,
            Description = request.PlatformDto.Description,
            LogoUrl = request.PlatformDto.LogoUrl,
            IsActive = true
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }
}
