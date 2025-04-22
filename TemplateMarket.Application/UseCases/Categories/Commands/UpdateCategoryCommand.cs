using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Category.Dtos;

namespace TemplateMarket.Application.UseCases.Categories.Commands;
public class UpdateCategoryCommand : UpdateCategoryDto, IRequest<CategoryResponse>
{
}

public class UpdateCategoryCommandHandler(
    IRepository<TemplateMarket.Domain.Entities.Category> _repository,
    IMapper _mapper
) : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOrThrow(request.Id);

        _mapper.Map(request, entity);

        await _repository.SaveChangesAsync();

        return _mapper.Map<CategoryResponse>(entity);
    }
}