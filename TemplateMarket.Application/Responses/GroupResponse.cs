namespace TemplateMarket.Application.Responses;

public record GroupResponse(
    string Name,
    string Description,
    IEnumerable<RoleResponse> Roles
);
