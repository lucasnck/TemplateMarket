using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
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
        var template = await _repository.GetByIdAsync(request.Id);

        if (template is null)
            throw new NotFoundException(nameof(Template), request.Id);

        return _mapper.Map<TemplateResponse>(template);
    }
}