using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Products.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Products.Commands;

public class CreateProductCommand : CreateProductDto, IRequest<long>
{
}

public class CreateProductCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<CreateProductCommand, long>
{
    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = _repo.Query<Product>().Any(t => t.Name == request.Name);
        if (alreadyExists)
            throw new AlreadyExistsException(nameof(Product));

        var entity = _mapper.Map<Product>(request);

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}