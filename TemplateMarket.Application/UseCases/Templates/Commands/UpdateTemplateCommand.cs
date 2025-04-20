using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Templates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Templates.Commands;

public record UpdateTemplateCommand : IRequest<TemplateResponse>
{
    public UpdateTemplateDto UpdateTemplateDto { get; set; }
}

public class UpdateTemplateHandler(
    IRepository<Template> _repository,
    IMapper _mapper
) : IRequestHandler<UpdateTemplateCommand, TemplateResponse>
{
    public async Task<TemplateResponse> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.UpdateTemplateDto.Id);

        if (entity is null) 
            throw new NotFoundException(nameof(Template), request.UpdateTemplateDto.Id);

        entity.Update(request.UpdateTemplateDto);

        await _repository.UpdateAsync(entity);
        await _repository.SaveChangesAsync();

        return _mapper.Map<TemplateResponse>(entity);
    }
}
