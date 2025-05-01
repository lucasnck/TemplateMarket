using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Showcases.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Showcases.Queries;

public record GetShowcasesQuery() : IRequest<IEnumerable<ShowcaseResponse>>;

public class GetShowcasesQueryHandler(
    IRepository<Showcase> _showcaseRepo,
    IMapper _mapper
) : IRequestHandler<GetShowcasesQuery, IEnumerable<ShowcaseResponse>>
{
    public async Task<IEnumerable<ShowcaseResponse>> Handle(GetShowcasesQuery request, CancellationToken ct)
    {
        var showcases = await _showcaseRepo.GetAllAsync();

        return showcases.Select(x => new ShowcaseResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Products = x.ShowcaseProducts.Select(x => _mapper.Map<ProductResponse>(x.Product))
        });
    }
}
