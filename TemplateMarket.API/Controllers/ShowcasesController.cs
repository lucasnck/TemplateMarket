using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Showcases.Queries;

namespace TemplateMarket.API.Controllers;

[Route("api/showcases")]
[ApiController]
public class ShowcasesController(IMediator _mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShowcase(long id)
        => Ok(await _mediator.Send(new GetShowcaseByIdQuery(id)));
}
