using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.Platforms.Commands;
using TemplateMarket.Application.UseCases.Platforms.Queries;
using TemplateMarket.Application.UseCases.Templates.Commands;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/[controller]")]
public class AdminPlatformsController(IMediator _mediator) : ApiControllerBase(_mediator)
{
    [Authorize]
    //[RoleFilter(Roles.Platform.Update)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlatformCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [Authorize]
    //[RoleFilter(Roles.Platform.Read)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetPlatformsQuery());
        return Ok(result);
    }

    [Authorize]
    //[RoleFilter(Roles.Platform.Read)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new GetPlatformByIdQuery(id));
        return Ok(result);
    }

    [Authorize]
    //[RoleFilter(Roles.Platform.Update)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _mediator.Send(new DeletePlatformCommand(id));
        return Ok(result);
    }

    [Authorize]
    //[RoleFilter(Roles.Platform.Update)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePlatformCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
