using TemplateMarket.Application.UseCases.Templates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Extensions
{
    public static class TemplateExtensions
    {
        public static void Update(this Template entity, UpdateTemplateDto updateRequest)
        {
            // Atualiza as propriedades da entidade com base nas propriedades não nulas do request
            if (!string.IsNullOrEmpty(updateRequest.Name))
                entity.Name = updateRequest.Name;

            if (!string.IsNullOrEmpty(updateRequest.Description))
                entity.Description = updateRequest.Description;

            if (updateRequest.Price != null)
                entity.Price = updateRequest.Price.Value;

            if (updateRequest.PlatformIds != null)
                entity.TemplatePlatforms = updateRequest.PlatformIds.Select(pid => new TemplatePlatform
                {
                    PlatformId = pid
                }).ToList();
        }
    }
}
