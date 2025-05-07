using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Products.Queries;

public record GetProductByIdQuery(long Id) : IRequest<ProductResponse>;

public class GetProductByIdQueryHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repo.SingleOrThrow<Product>(x => x.Id == request.Id);
        return _mapper.Map<ProductResponse>(entity);
    }
}