using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Attributes;
using TemplateMarket.Application.UseCases.UserCompanyGroup.Commands;
using TemplateMarket.Domain.Roles;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/[controller]")]
[ApiController]
public class AdminUserCompanyGroupsController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    [RoleFilter(Roles.UserCompanyGroup.Update)]
    [HttpPost]
    public async Task<IActionResult> UpdateUserCompanyGroup(UpdateUserCompanyGroupCommand command)
        => Ok(await _mediator.Send(command));
}
