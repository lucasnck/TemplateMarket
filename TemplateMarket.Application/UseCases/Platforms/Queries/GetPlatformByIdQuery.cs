using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Queries;

public record GetPlatformByIdQuery(long id) : IRequest<PlatformResponse>;

public class GetPlatformByIdQueryHandler(
    IRepository _repo, 
    IMapper _mapper
) : IRequestHandler<GetPlatformByIdQuery, PlatformResponse>
{
    public async Task<PlatformResponse> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
    {
        var platform = await _repo.SingleOrThrow<Platform>(x => x.Id == request.id);

        return _mapper.Map<PlatformResponse>(platform);
    }
}

