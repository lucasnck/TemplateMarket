using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.UseCases.Templates.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
{
}

public class GetCategoriesQueryHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryResponse>>
{
    public async Task<IEnumerable<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = _repo.Query<TemplateMarket.Domain.Entities.Category>().AsEnumerable();
        return _mapper.Map<IEnumerable<CategoryResponse>>(result);
    }
}
