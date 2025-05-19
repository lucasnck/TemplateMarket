using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Attributes;
using TemplateMarket.Application.UseCases.Groups.Commands;
using TemplateMarket.Domain.Roles;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
public class GroupsController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    //[RoleFilter(Roles.Group.Update)]
    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] CreateGroupCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    //[RoleFilter(Roles.Group.Update)]
    [HttpPut]
    public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupCommand command)
        => Ok(await _mediator.Send(command));
}
