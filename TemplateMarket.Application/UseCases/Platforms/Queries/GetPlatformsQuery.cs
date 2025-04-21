using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Queries;

public class GetAllPlatformsQuery : IRequest<IEnumerable<PlatformResponse>>
{
}

public class GetAllPlatformsQueryHandler(
    IRepository<Platform> _repository, 
    IMapper _mapper
) : IRequestHandler<GetAllPlatformsQuery, IEnumerable<PlatformResponse>>
{
    public async Task<IEnumerable<PlatformResponse>> Handle(GetAllPlatformsQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<List<PlatformResponse>>(result);
    }
}

