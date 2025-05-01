using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Products.Commands;

public record DeleteProductCommand(long Id) : IRequest<Unit>;

public class DeleteProductCommandHandler(
    IRepository<Product> _repository
) : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOrThrow(request.Id);

        await _repository.DeleteAsync(entity);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}
