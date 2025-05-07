using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Templates.Commands;

public record DeletePlatformCommand(long Id) : IRequest<Unit>;

public class DeletePlatformCommandHandler(
    IRepository _repo
) : IRequestHandler<DeletePlatformCommand, Unit>
{
    public async Task<Unit> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.SingleOrThrow<Platform>(x => x.Id == request.Id);

        _repo.Remove(entity);
        await _repo.SaveChangesAsync();

        return Unit.Value;
    }
}
