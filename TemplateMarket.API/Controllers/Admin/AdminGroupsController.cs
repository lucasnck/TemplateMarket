using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.Groups.Commands;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/[controller]")]
public class AdminGroupsController(IMediator _mediator) : ApiControllerBase(_mediator)
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
