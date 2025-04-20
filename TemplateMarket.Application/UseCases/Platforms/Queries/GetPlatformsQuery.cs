using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Queries;

public class GetAllPlatformsQuery : IRequest<List<PlatformResponse>>
{
}

public class GetAllPlatformsQueryHandler(IRepository<Platform> _repository, IMapper _mapper)
    : IRequestHandler<GetAllPlatformsQuery, List<PlatformResponse>>
{
    public async Task<List<PlatformResponse>> Handle(GetAllPlatformsQuery request, CancellationToken cancellationToken)
    {
        var platforms = await _repository.GetAllAsync();

        return _mapper.Map<List<PlatformResponse>>(platforms.ToList());
    }
}

