using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Templates.Commands;

public record DeleteTemplateCommand(long Id) : IRequest<Unit>;

public class DeleteTemplateCommandHandler(
    IRepository<Template> _repository
) : IRequestHandler<DeleteTemplateCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
            throw new NotFoundException(nameof(Template), request.Id);

        await _repository.DeleteAsync(entity);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}
