using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Showcases.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Showcases.Queries;

public record GetShowcaseByIdQuery(long Id) : IRequest<ShowcaseResponse>;

public class GetShowcaseByIdQueryHandler(
    IRepository<Showcase> _showcaseRepo,
    IMapper _mapper
) : IRequestHandler<GetShowcaseByIdQuery, ShowcaseResponse>
{
    public async Task<ShowcaseResponse> Handle(GetShowcaseByIdQuery request, CancellationToken ct)
    {
        var showcase = await _showcaseRepo.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Showcase), request.Id);

        var response = _mapper.Map<ShowcaseResponse>(showcase);

        response.Products.Concat(_mapper.Map<IEnumerable<ProductResponse>>(showcase.Category?.Products));

        return response;
    }
}
