using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Products.Commands;
using TemplateMarket.Application.UseCases.Products.Queries;

namespace TemplateMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    //[RoleFilter(Roles.Product.Update)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    //[RoleFilter(Roles.Product.Read)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetProductQuery()));

    [Authorize]
    //[RoleFilter(Roles.Product.Read)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
        => Ok(await _mediator.Send(new GetProductByIdQuery(id)));

    [Authorize]
    //[RoleFilter(Roles.Product.Update)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
        => Ok(await _mediator.Send(new DeleteProductCommand(id)));

    [Authorize]
    //[RoleFilter(Roles.Product.Update)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductCommand command)
        => Ok(await _mediator.Send(command));
}
