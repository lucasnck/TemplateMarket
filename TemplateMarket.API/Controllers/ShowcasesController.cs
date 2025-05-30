using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.Showcases.Queries;

namespace TemplateMarket.API.Controllers;

[Route("api/showcases")]
public class ShowcasesController(IMediator _mediator) : ApiControllerBase(_mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShowcase(long id)
        => Ok(await _mediator.Send(new GetShowcaseByIdQuery(id)));
}
