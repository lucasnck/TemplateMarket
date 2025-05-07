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
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<CreateCategoryCommand, long>
{
    public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = (_repo.Query<TemplateMarket.Domain.Entities.Category>().Any(t => t.Name == request.Name));
        if (alreadyExists)
            throw new AlreadyExistsException(nameof(Category));

        var entity = _mapper.Map<TemplateMarket.Domain.Entities.Category>(request);

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}