using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Attributes;
using TemplateMarket.Application.UseCases.Orders.Commands.CreateOrder;
using TemplateMarket.Domain.Roles;

namespace TemplateMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IMediator _mediator) : ControllerBase
{ 
    [Authorize]
    //[RoleFilter(Roles.Orders.Create)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        => Ok(await _mediator.Send(command));
}