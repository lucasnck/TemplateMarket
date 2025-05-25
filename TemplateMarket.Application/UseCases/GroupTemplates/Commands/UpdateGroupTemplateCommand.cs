using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.GroupTemplates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.GroupTemplates.Commands;

public class UpdateGroupTemplateCommand : UpdateGroupTemplateDto, IRequest<long>
{
}

public class UpdateGroupTemplateCommandHandler(
    IRepository _repo
) : IRequestHandler<UpdateGroupTemplateCommand, long>
{
    public async Task<long> Handle(UpdateGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        var groupTemplate = await _repo.SingleOrThrow<GroupTemplate>(gt => gt.Id == request.Id);

        var groups = _repo.Query<Group>()
            .Where(g => request.GroupIds.Contains(g.Id))
            .ToList();

        groupTemplate.Groups = groups;

        return groupTemplate.Id;
    }
}
