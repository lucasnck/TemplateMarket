using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Attributes;
using TemplateMarket.Application.UseCases.UserCompanies.Commands;
using TemplateMarket.Domain.Roles;

namespace TemplateMarket.API.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class UserCompaniesController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    [RoleFilter(Roles.UserCompany.Update)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCompanyOwnerCommand command)
        => Ok(await _mediator.Send(command));

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update([FromBody] UpdateUserCompanyCommand command)
    //    => Ok(await _mediator.Send(command));

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetUserCompanyById(long id)
    //    => Ok(await _mediator.Send(new GetUserCompanyByIdQuery(id)));

    //[HttpGet]
    //public async Task<IActionResult> GetUserCompanies()
    //    => Ok(await _mediator.Send(new GetUserCompaniesQuery()));
}
