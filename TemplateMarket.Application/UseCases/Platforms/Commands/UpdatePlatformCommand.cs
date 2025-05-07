using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Platforms.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Commands;

public class UpdatePlatformCommand : UpdatePlatformDto, IRequest<PlatformResponse>
{
}

public class UpdatePlatformCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<UpdatePlatformCommand, PlatformResponse>
{
    public async Task<PlatformResponse> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = await _repo.SingleOrThrow<Platform>(x => x.Id == request.Id);

        _mapper.Map(request, platform);

        await _repo.SaveChangesAsync();

        return _mapper.Map<PlatformResponse>(platform);
    }
}
