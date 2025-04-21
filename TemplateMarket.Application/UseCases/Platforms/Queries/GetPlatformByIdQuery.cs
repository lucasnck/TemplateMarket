using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Platforms.Queries;

public class GetPlatformByIdQuery : IRequest<PlatformResponse>
{
    public long Id { get; set; }
}

public class GetPlatformByIdQueryHandler(IRepository<Platform> _repository, IMapper _mapper)
    : IRequestHandler<GetPlatformByIdQuery, PlatformResponse>
{
    public async Task<PlatformResponse> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
    {
        var platform = await _repository.GetByIdAsync(request.Id);
        if (platform == null)
            throw new NotFoundException(nameof(Platform), request.Id);

        return _mapper.Map<PlatformResponse>(platform);
    }
}

