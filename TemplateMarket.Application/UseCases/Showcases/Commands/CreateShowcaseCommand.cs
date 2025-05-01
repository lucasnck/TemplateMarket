using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Showcases.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Showcases.Commands;

public class CreateShowcaseCommand : IRequest<long>
{
    public CreateShowcaseDto Showcase;

    public List<string>? SKUs { get; init; }
    public long? CategoryId { get; init; }
}

public class CreateShowcaseCommandHandler(
    IRepository<Showcase> _showcaseRepo,
    IRepository<Product> _productRepo,
    IMapper _mapper
) : IRequestHandler<CreateShowcaseCommand, long>
{
    public async Task<long> Handle(CreateShowcaseCommand request, CancellationToken ct)
    {
        var showcase = _mapper.Map<Showcase>(request.Showcase);

        List<Product> selectedProducts = new();

        if (request.SKUs is not null && request.SKUs.Any())
        {
            selectedProducts = (await _productRepo.FindAsync(p => request.SKUs.Contains(p.SKU))).ToList();
        }

        foreach (var product in selectedProducts)
        {
            showcase.ShowcaseProducts.Add(new ()
            {
                Product = product,
                Showcase = showcase,
            });
        }

        await _showcaseRepo.AddAsync(showcase);
        await _showcaseRepo.SaveChangesAsync();

        return showcase.Id;
    }
}
