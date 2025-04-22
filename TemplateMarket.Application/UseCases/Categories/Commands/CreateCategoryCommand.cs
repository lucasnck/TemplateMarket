using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Category.Dtos;

namespace TemplateMarket.Application.UseCases.Categories.Commands;

public class CreateCategoryCommand : CreateCategoryDto, IRequest<long>
{
}   

public class CreateCategoryHandler(
    IRepository<TemplateMarket.Domain.Entities.Category> _repository,
    IMapper _mapper
) : IRequestHandler<CreateCategoryCommand, long>
{
    public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = (await _repository.FindAsync(t => t.Name == request.Name)).Any();
        if (alreadyExists)
            throw new AlreadyExistsException(nameof(Category));

        var entity = _mapper.Map<TemplateMarket.Domain.Entities.Category>(request);

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }
}