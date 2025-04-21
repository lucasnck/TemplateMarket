using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Platforms.Commands;
using TemplateMarket.Application.UseCases.Platforms.Queries;
using TemplateMarket.Application.UseCases.Templates.Commands;

namespace TemplateMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlatformController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlatformCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPlatformsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new GetPlatformByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _mediator.Send(new DeletePlatformCommand(id));
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePlatformCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
