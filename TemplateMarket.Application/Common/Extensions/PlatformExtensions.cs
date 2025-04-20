using TemplateMarket.Application.UseCases.Platforms.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Extensions
{
    public static class PlatformExtensions
    {
        public static void Update(this Platform entity, UpdatePlatformDto updateRequest)
        {
            // Atualiza as propriedades da entidade com base nas propriedades não nulas do request
            if (!string.IsNullOrEmpty(updateRequest.Name))
                entity.Name = updateRequest.Name;

            if (!string.IsNullOrEmpty(updateRequest.Description))
                entity.Description = updateRequest.Description;

            if (!string.IsNullOrEmpty(updateRequest.LogoUrl))
                entity.LogoUrl = updateRequest.LogoUrl;

            if (updateRequest.IsActive)
                entity.IsActive = updateRequest.IsActive;
        }
    }
}
