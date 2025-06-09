using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TemplateMarket.API.Attributes;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.UserCompanies.Commands;
using TemplateMarket.Application.UseCases.UserCompanies.Queries;
using TemplateMarket.Domain.Roles;

namespace TemplateMarket.API.Controllers;

[Route("api/[controller]")]
public class UserCompaniesController(IMediator _mediator) : ApiControllerBase(_mediator)
{
    [Authorize]
    [RoleFilter(Roles.UserCompany.Update)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCompanyOwnerCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    [RoleFilter(Roles.Product.Read)]
    [HttpGet]
    public async Task<IActionResult> List(
        [FromQuery] SieveModel sieveModel
    )
    {
        var query = new GetUserCompaniesQuery(sieveModel);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

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
