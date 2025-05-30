using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TemplateMarket.API.Common;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly IMediator _mediator;

    protected ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }
}
