using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMarket.Application.UseCases.Categories.Commands;
using TemplateMarket.Application.UseCases.Templates.Queries;

namespace TemplateMarket.API.Controllers.Admin;

[Route("api/[controller]")]
[ApiController]
public class AdminCategoriesController(IMediator _mediator) : ControllerBase
{
    [Authorize]
    //[RoleFilter(Roles.Category.Update)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    //[RoleFilter(Roles.Category.Read)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetCategoriesQuery()));

    [Authorize]
    //[RoleFilter(Roles.Category.Read)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
        => Ok(await _mediator.Send(new GetCategoryByIdQuery(id)));

    [Authorize]
    //[RoleFilter(Roles.Category.Update)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
        => Ok(await _mediator.Send(new DeleteCategoryCommand(id)));

    [Authorize]
    //[RoleFilter(Roles.Category.Update)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryCommand command)
        => Ok(await _mediator.Send(command));
}
