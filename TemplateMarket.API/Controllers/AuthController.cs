using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TemplateMarket.Application.UseCases.Auth.Commands.ChangePassword;
using TemplateMarket.Application.UseCases.Auth.Commands.ForgotPassword;
using TemplateMarket.Application.UseCases.Auth.Commands.ResetPassword;
using TemplateMarket.Application.UseCases.Auth.Queries.GetSelf;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator _mediator) : ControllerBase
{
    [HttpPost("register")]
    [AllowAnonymous]
    [EnableRateLimiting("PublicEndpoints")]
    [EnableCors("AllowFrontend")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("login")]
    [AllowAnonymous]
    [EnableRateLimiting("PublicEndpoints")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    [EnableRateLimiting("PublicEndpoints")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command) 
        => Ok(await _mediator.Send(command));

    [HttpPost("reset-password")]
    [AllowAnonymous]
    [EnableRateLimiting("PublicEndpoints")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    [HttpGet("self")]
    public async Task<IActionResult> GetSelf()
        => Ok(await _mediator.Send(new GetSelfQuery()));

}