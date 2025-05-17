using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Showcases.Commands;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
public class RolesController(IMediator _mediator) : ControllerBase
{
    //[HttpPost]
    //public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    //    => Ok(await _mediator.Send(command));
}
