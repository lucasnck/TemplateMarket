using TemplateMarket.Application.Common.Interfaces;

namespace TemplateMarket.Application.Common.Services;

public class EmailNotification : IEmailNotification
{
    public Task SendNotificationAsync(string to, string subject, string Type, string body)
    {
        // implementar no futuro

        return Task.CompletedTask;
    }
}
