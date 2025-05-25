using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.GroupTemplates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.GroupTemplates.Commands;

public class CreateGroupTemplateCommand : CreateGroupTemplateDto, IRequest<long>
{
}

public class CreateGroupTemplateCommandHandler(
    IRepository _repo
) : IRequestHandler<CreateGroupTemplateCommand, long>
{
    public async Task<long> Handle(CreateGroupTemplateCommand request, CancellationToken cancellationToken)
    {
        var groups = _repo.Query<Group>()
            .Where(g => request.GroupIds.Contains(g.Id))
            .ToList();

        var groupTemplate = new GroupTemplate()
        {
            TemplateKey = request.TemplateKey,
            Groups = groups
        };

        await _repo.AddAsync(groupTemplate);
        await _repo.SaveChangesAsync();

        return groupTemplate.Id;
    }
}
