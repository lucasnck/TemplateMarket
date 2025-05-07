using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Products.Queries;

public class GetProductQuery : IRequest<IEnumerable<ProductResponse>>
{
}

public class GetProductQueryHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<GetProductQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = _repo.Query<Product>().AsEnumerable();
        return _mapper.Map<IEnumerable<ProductResponse>>(result);
    }
}
