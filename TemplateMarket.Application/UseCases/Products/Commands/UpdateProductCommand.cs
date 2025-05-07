using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Products.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Products.Commands;

public class UpdateProductCommand : UpdateProductDto, IRequest<ProductResponse>
{
}

public class UpdateProductHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.SingleOrThrow<Product>(x => x.Id == request.Id);

        _mapper.Map(request, entity);

        await _repo.SaveChangesAsync();

        return _mapper.Map<ProductResponse>(entity);
    }
}
