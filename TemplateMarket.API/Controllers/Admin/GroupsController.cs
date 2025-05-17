using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Groups.Commands;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
public class GroupsController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] CreateGroupCommand command)
        => Ok(await _mediator.Send(command));

    //[HttpPut]
    //public async Task<IActionResult> AddGroupRole([FromBody] UpdateGroupCommand command)
    //    => Ok(await _mediator.Send(command));
}
