using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;

namespace TemplateMarket.Application.UseCases.Categories.Commands;

public record DeleteCategoryCommand(long Id) : IRequest<Unit>;

public class DeleteCategoryCommandHandler(
    IRepository<TemplateMarket.Domain.Entities.Category> _repository
) : IRequestHandler<DeleteCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOrThrow(request.Id);

        await _repository.DeleteAsync(entity);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}
