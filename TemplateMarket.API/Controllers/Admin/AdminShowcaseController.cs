using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.Showcases.Commands;
using TemplateMarket.Application.UseCases.Showcases.Queries;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/[controller]")]
public class AdminShowcaseController(IMediator _mediator) : ApiControllerBase(_mediator)
{
    [Authorize]
    //[RoleFilter(Roles.Showcase.Update)]
    [HttpPost]
    public async Task<IActionResult> CreateShowcase([FromBody] CreateShowcaseCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    //[RoleFilter(Roles.Showcase.Read)]
    [HttpGet]
    public async Task<IActionResult> GetShowcases()
        => Ok(await _mediator.Send(new GetShowcasesQuery()));
}
