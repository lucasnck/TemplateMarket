using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Roles.Commands;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
public class RolesController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    //[RoleFilter(Roles.Role.Update)]
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        => Ok(await _mediator.Send(command));
}
