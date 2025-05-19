namespace TemplateMarket.API.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class RoleFilterAttribute : Attribute
{
    public string Role { get; }

    public RoleFilterAttribute(string role)
    {
        Role = role;
    }
}
