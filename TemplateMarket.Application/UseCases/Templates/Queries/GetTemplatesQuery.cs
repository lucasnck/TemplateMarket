using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Templates.Queries;

public class GetTemplatesQuery : IRequest<IEnumerable<TemplateResponse>>
{
}

public class GetTemplatesQueryHandler(
    IRepository<Template> _repository,
    IMapper _mapper
) : IRequestHandler<GetTemplatesQuery, IEnumerable<TemplateResponse>>
{
    public async Task<IEnumerable<TemplateResponse>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TemplateResponse>>(result);
    }
}
