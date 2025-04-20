using MediatR;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.UseCases.Templates.Dtos;

namespace TemplateMarket.Application.UseCases.Templates.Commands;

public class CreateTemplateCommand : IRequest<Guid>
{
    public CreateTemplateDto CreateTemplateDto { get; set; }
}

public class CreateTemplateCommandHandler(IRepository<Template> _repository) : IRequestHandler<CreateTemplateCommand, Guid>
{
    public async Task<Guid> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = (await _repository.FindAsync(t => t.Name == request.CreateTemplateDto.Name)).Any();
        if (alreadyExists)
            throw new Exception("Template already exists.");

        var entity = new Template
        {
            Name = request.CreateTemplateDto.Name,
            Price = request.CreateTemplateDto.Price,
            PreviewUrl = request.CreateTemplateDto.PreviewUrl,
            ThumbnailUrl = request.CreateTemplateDto.ThumbnailUrl,
            Description = request.CreateTemplateDto.Description,
            TemplatePlatforms = request.CreateTemplateDto.PlatformIds.Select(pid => new TemplatePlatform
            {
                PlatformId = pid
            }).ToList()
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }
}