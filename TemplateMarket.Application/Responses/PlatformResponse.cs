namespace TemplateMarket.Application.Responses;

public class PlatformResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
    public bool IsActive { get; set; }
}
