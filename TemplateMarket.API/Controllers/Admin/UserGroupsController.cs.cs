using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Showcases.Commands;
using TemplateMarket.Application.UseCases.UserGroups.Commands;

namespace TemplateMarket.API.Controllers.Admin;


[Route("api/admin/[controller]")]
[ApiController]
public class UserGroupsController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    //[RoleFilter(Roles.UserGroup.Update)]
    [HttpPost]
    public async Task<IActionResult> CreateUserGroup([FromBody] CreateUserGroupCommand command)
        => Ok(await _mediator.Send(command));

}
