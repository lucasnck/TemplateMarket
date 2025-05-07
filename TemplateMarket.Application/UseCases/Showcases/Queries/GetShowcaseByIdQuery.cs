using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Showcases.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Showcases.Queries;

public record GetShowcaseByIdQuery(long Id) : IRequest<ShowcaseResponse>;

public class GetShowcaseByIdQueryHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<GetShowcaseByIdQuery, ShowcaseResponse>
{
    public async Task<ShowcaseResponse> Handle(GetShowcaseByIdQuery request, CancellationToken ct)
    {
        var showcase = await _repo.SingleOrThrow<Showcase>(x => x.Id == request.Id);

        var response = _mapper.Map<ShowcaseResponse>(showcase);

        response.Products.Concat(_mapper.Map<IEnumerable<ProductResponse>>(showcase.Category?.Products));

        return response;
    }
}
