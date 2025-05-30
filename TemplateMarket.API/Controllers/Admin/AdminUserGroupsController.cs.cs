using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Attributes;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.UserGroups.Commands;
using TemplateMarket.Domain.Roles;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/[controller]")]
public class UserGroupsController(IMediator _mediator) : ApiControllerBase(_mediator)
{
    [Authorize]
    [RoleFilter(Roles.UserGroup.Update)]
    [HttpPut]
    public async Task<IActionResult> UpdateUserGroup([FromBody] UpdateUserGroupCommand command)
        => Ok(await _mediator.Send(command));

}
