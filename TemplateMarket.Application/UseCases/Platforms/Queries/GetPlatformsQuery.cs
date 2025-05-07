using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Queries;

public class GetPlatformsQuery : IRequest<IEnumerable<PlatformResponse>>
{
}

public class GetPlatformsQueryHandler(
    IRepository _repo, 
    IMapper _mapper
) : IRequestHandler<GetPlatformsQuery, IEnumerable<PlatformResponse>>
{
    public async Task<IEnumerable<PlatformResponse>> Handle(GetPlatformsQuery request, CancellationToken cancellationToken)
    {
        var result = _repo.Query<Platform>().AsEnumerable();
        return _mapper.Map<List<PlatformResponse>>(result);
    }
}

