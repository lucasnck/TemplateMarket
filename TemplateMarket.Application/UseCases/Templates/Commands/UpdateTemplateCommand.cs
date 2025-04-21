using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Templates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Templates.Commands;

public class UpdateTemplateCommand : UpdateTemplateDto, IRequest<TemplateResponse>
{
}

public class UpdateTemplateHandler(
    IRepository<Template> _repository,
    IMapper _mapper
) : IRequestHandler<UpdateTemplateCommand, TemplateResponse>
{
    public async Task<TemplateResponse> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOrThrow(request.Id);

        _mapper.Map(request, entity);

        await _repository.SaveChangesAsync();

        return _mapper.Map<TemplateResponse>(entity);
    }
}
