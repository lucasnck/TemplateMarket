using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Platforms.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Commands;

public class UpdatePlatformCommand : IRequest<PlatformResponse>
{
    public UpdatePlatformDto PlatformDto { get; set; } = default!;
}

public class UpdatePlatformCommandHandler(IRepository<Platform> _repository, IMapper _mapper)
    : IRequestHandler<UpdatePlatformCommand, PlatformResponse>
{
    public async Task<PlatformResponse> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = await _repository.GetByIdAsync(request.PlatformDto.Id);
        if (platform == null)
            throw new NotFoundException(nameof(Platform), request.PlatformDto.Id);

        platform.Update(request.PlatformDto);

        await _repository.SaveChangesAsync();

        return _mapper.Map<PlatformResponse>(platform);
    }
}
