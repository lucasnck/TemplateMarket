namespace TemplateMarket.API.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class RoleFilterAttribute(string role) : Attribute
{
    public string Role { get; } = role;
}