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
    IRepository<Product> _repository,
    IMapper _mapper
) : IRequestHandler<CreateProductCommand, long>
{
    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = (await _repository.FindAsync(t => t.Name == request.Name)).Any();
        if (alreadyExists)
            throw new AlreadyExistsException(nameof(Product));

        var entity = _mapper.Map<Product>(request);

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }
}