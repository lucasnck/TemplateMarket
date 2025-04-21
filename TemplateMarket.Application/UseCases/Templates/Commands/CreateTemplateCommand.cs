using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Templates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Templates.Commands;

public class CreateTemplateCommand : CreateTemplateDto, IRequest<long>
{
}

public class CreateTemplateCommandHandler(
    IRepository<Template> _repository, 
    IMapper _mapper
) : IRequestHandler<CreateTemplateCommand, long>
{
    public async Task<long> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = (await _repository.FindAsync(t => t.Name == request.Name)).Any();
        if (alreadyExists)
            throw new AlreadyExistsException(nameof(Template));

        var entity = _mapper.Map<Template>(request);

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }
}