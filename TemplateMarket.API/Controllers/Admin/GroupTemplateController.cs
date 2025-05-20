using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Attributes;
using TemplateMarket.Application.UseCases.GroupTemplates.Commands;
using TemplateMarket.Domain.Roles;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
public class GroupTemplateController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    [RoleFilter(Roles.GroupTemplate.Update)]
    [HttpPost]
    public async Task<IActionResult> UpdateUserCompanyGroup(CreateGrouptemplateCommand command)
        => Ok(await _mediator.Send(command));
}
