using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Orders.Commands.CreateOrder;

namespace TemplateMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IMediator _mediator) : ControllerBase
{ 
    [Authorize(Roles = "Customer")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    => Ok(await _mediator.Send(command));
}