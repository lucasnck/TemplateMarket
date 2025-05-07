using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Products.Commands;

public record DeleteProductCommand(long Id) : IRequest<Unit>;

public class DeleteProductCommandHandler(
    IRepository _repo
) : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.SingleOrThrow<Product>(x => x.Id == request.Id);

        _repo.Remove(entity);
        await _repo.SaveChangesAsync();

        return Unit.Value;
    }
}
