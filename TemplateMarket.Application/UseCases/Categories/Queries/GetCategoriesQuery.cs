using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.UseCases.Templates.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
{
}

public class GetCategoriesQueryHandler(
    IRepository<TemplateMarket.Domain.Entities.Category> _repository,
    IMapper _mapper
) : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryResponse>>
{
    public async Task<IEnumerable<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryResponse>>(result);
    }
}
