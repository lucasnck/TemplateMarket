using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.GroupTemplates.Commands;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/[controller]")]
public class AdminGroupTemplateController(IMediator _mediator) : ApiControllerBase(_mediator)
{
    [Authorize]
    //[RoleFilter(Roles.GroupTemplate.Update)]
    [HttpPost]
    public async Task<IActionResult> CreateGroupTemplate(CreateGroupTemplateCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    //[RoleFilter(Roles.GroupTemplate.Update)]
    [HttpPut]
    public async Task<IActionResult> UpdateGroupTemplate([FromBody] UpdateGroupTemplateCommand command)
        => Ok(await _mediator.Send(command));
}
