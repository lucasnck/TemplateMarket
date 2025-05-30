using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.Orders.Commands.CreateOrder;

namespace TemplateMarket.API.Controllers;

[Route("api/[controller]")]
public class OrdersController(IMediator _mediator) : ApiControllerBase(_mediator)
{ 
    [Authorize]
    //[RoleFilter(Roles.Orders.Create)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        => Ok(await _mediator.Send(command));
}