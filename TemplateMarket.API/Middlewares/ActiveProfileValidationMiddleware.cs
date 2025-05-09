using TemplateMarket.Application.Common.Interfaces.Permissions;

public class ActiveProfileValidationMiddleware : IMiddleware
{
    private readonly IActiveProfileService _profile;

    public ActiveProfileValidationMiddleware(IActiveProfileService profile)
    {
        _profile = profile;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var header = context.Request.Headers["X-Active-Company"].FirstOrDefault();

            if(header == null)
            {
                await next(context);
                return;
            }
            else
            {
                var current = await _profile.GetCurrentProfile();

                if (current.ActiveProfile.Identification != header)
                    throw new ActiveProfileMismatchException(current, header);
            }
        }

        await next(context);
    }
}
