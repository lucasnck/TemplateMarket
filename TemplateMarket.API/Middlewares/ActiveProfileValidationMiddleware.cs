
using System.Net;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

public class ActiveProfileValidationMiddleware(
    IActiveProfileService _activeProfile,
    IRepository _repo
) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var userId = _activeProfile.TryGetUserId();

        // Ignora requisições públicas ou sem autenticação
        if (!context.User.Identity?.IsAuthenticated ?? true)
        {
            await next(context);
            return;
        }

        // Extrai header x-auth-company
        var headerCompanyId = context.Request.Headers["x-auth-company"].FirstOrDefault();

        var userCompanies = _repo.Query<UserCompany>()
            .Where(uc => uc.UserId == userId);
        var activeCompany = userCompanies.FirstOrDefault(uc => uc.IsActive);

        if (string.IsNullOrEmpty(headerCompanyId))
        {
            // Se o header não foi enviado e tem empresa ativa, tudo certo
            await next(context);
            return;
        }

        // Verifica se a empresa do header pertence ao usuário
        var requestedCompanyId = long.Parse(headerCompanyId);
        var matching = userCompanies.FirstOrDefault(uc => uc.CompanyId == requestedCompanyId);

        if (matching == null)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            await context.Response.WriteAsJsonAsync(new
            {
                title = "Perfil inválido",
                detail = "O perfil solicitado não pertence a esse usuário."
            });
            return;
        }

        // Se não for o perfil ativo, troca
        if (!matching.IsActive)
        {
            foreach (var uc in userCompanies)
                uc.IsActive = uc.CompanyId == requestedCompanyId;

            await _repo.SaveChangesAsync();
        }

        await next(context);
    }
}
