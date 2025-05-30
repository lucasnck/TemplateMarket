using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TemplateMarket.API.Common;
using TemplateMarket.Application.UseCases.Auth.Commands;
using TemplateMarket.Application.UseCases.Auth.Commands.ChangePassword;
using TemplateMarket.Application.UseCases.Auth.Commands.ForgotPassword;
using TemplateMarket.Application.UseCases.Auth.Commands.ResetPassword;
using TemplateMarket.Application.UseCases.Auth.Queries;
using TemplateMarket.Application.UseCases.Auth.Queries.GetSelf;

[Route("api/[controller]")]
public class AuthController(IMediator _mediator) : ApiControllerBase(_mediator)
{
    [HttpPost("register")]
    [AllowAnonymous]
    [EnableRateLimiting("PublicEndpoints")]
    [EnableCors("AllowFrontend")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("verify-email")]
    [AllowAnonymous]
    [EnableRateLimiting("PublicEndpoints")]
    [EnableCors("AllowFrontend")]
    public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailCommand command)
        => Ok(await _mediator.Send(command));

    [Authorize]
    [HttpPost("resend-email-verification")]
    public async Task<IActionResult> ResendEmailVerification([FromBody] ResendEmailVerificationCommand command)
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

    [Authorize]
    [HttpGet("self/profiles")]
    public async Task<IActionResult> GetSelfProfiles()
        => Ok(await _mediator.Send(new GetSelfProfilesQuery()));

    [Authorize]
    [HttpPut("self/profiles/switch")]
    public async Task<IActionResult> PutSelfProfilesSwitch([FromBody] SelfProfileSwitchCommand command)
        => Ok(await _mediator.Send(command));
}