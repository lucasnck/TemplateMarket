using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.UseCases.Templates.Queries;

public record GetCategoryByIdQuery(long Id) : IRequest<CategoryResponse>;

public class GetCategoryByIdQueryHandler(
    IRepository<TemplateMarket.Domain.Entities.Category> _repository,
    IMapper _mapper
) : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOrThrow(request.Id);
        return _mapper.Map<CategoryResponse>(entity);
    }
}