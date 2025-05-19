using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TemplateMarket.API.Attributes;
using TemplateMarket.Application.Common.Interfaces.Permissions;

public class RoleFilter(IActiveProfileService profileService) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        if (!context.ActionDescriptor.EndpointMetadata
            .OfType<RoleFilterAttribute>()
            .Select(a => a.Role).Any())
        {
            await next();
            return;
        }

        var requiredRoles = context.ActionDescriptor.EndpointMetadata
            .OfType<RoleFilterAttribute>()
            .Select(a => a.Role)
            .ToList();

        if (requiredRoles.Count == 0)
        {
            await next();
            return;
        }

        var current = await profileService.GetCurrentProfile();

        var hasAllRoles = requiredRoles.All(role =>
            current.ActiveProfile.Roles.Contains(role, StringComparer.OrdinalIgnoreCase) ||
            current.ActiveProfile.Roles.Contains("*", StringComparer.OrdinalIgnoreCase));

        if (!hasAllRoles)
        {
            context.Result = new ObjectResult(new
            {
                success = false,
                errors = new[]
                {
                    new { code = "Forbidden", message = "You do not have the required role to access this resource." }
                }
            })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
            return;
        }

        await next();
    }
}
