using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;

namespace TemplateMarket.Application.UseCases.Categories.Commands;

public record DeleteCategoryCommand(long Id) : IRequest<Unit>;

public class DeleteCategoryCommandHandler(
    IRepository _repo
) : IRequestHandler<DeleteCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.SingleOrThrow<TemplateMarket.Domain.Entities.Category>(x => x.Id == request.Id);

        _repo.Remove<TemplateMarket.Domain.Entities.Category>(entity);
        await _repo.SaveChangesAsync();

        return Unit.Value;
    }
}
