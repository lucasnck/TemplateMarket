using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Templates.Queries;
public record GetTemplateByIdQuery(long Id) : IRequest<TemplateResponse>;

public class GetTemplateByIdQueryHandler(
    IRepository<Template> _repository,
    IMapper _mapper
) : IRequestHandler<GetTemplateByIdQuery, TemplateResponse>
{
    public async Task<TemplateResponse> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOrThrow(request.Id);
        return _mapper.Map<TemplateResponse>(entity);
    }
}