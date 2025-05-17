using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Showcases.Commands;
using TemplateMarket.Application.UseCases.Showcases.Queries;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
public class ShowcaseAdminController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateShowcase([FromBody] CreateShowcaseCommand command)
        => Ok(await _mediator.Send(command));

    [HttpGet]
    public async Task<IActionResult> GetShowcases()
        => Ok(await _mediator.Send(new GetShowcasesQuery()));
}
