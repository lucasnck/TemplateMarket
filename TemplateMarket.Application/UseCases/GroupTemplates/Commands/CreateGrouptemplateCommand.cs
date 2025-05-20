using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.GroupTemplates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.GroupTemplates.Commands;

public class CreateGrouptemplateCommand : CreateGrouptemplateCommandDto, IRequest<long>
{
}

public class CreateGrouptemplateCommandHandler(
    IRepository _repo,
    IMapper _mapper
) : IRequestHandler<CreateGrouptemplateCommand, long>
{
    public async Task<long> Handle(CreateGrouptemplateCommand request, CancellationToken cancellationToken)
    {
        var groups = _repo.Query<Group>().Where(g => request.GroupIds.Contains(g.Id));

        var entity = _mapper.Map<GroupTemplate>(request);

        await _repo.UpdateAsync(entity);
        await _repo.SaveChangesAsync();

        return entity.Id;
    }
}
