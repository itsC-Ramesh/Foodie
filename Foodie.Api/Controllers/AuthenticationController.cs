using Foodie.Application.Authentication;
using Foodie.Application.Authentication.Commands.Register;
using Foodie.Application.Authentication.Queries.Login;
using Foodie.Contracts.Authentication;
using Foodie.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : BaseController
{
    private readonly ISender _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var command = new RegisterCommand(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);

        var authResult = await _mediator.Send(query);

        if (authResult.IsError
            && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);

        return authResult.Match(authResult => Ok(MapAuthResult(authResult)), Problem);
    }

    private static AuthenticationResponse MapAuthResult(
        AuthenticationResult authResult) => new AuthenticationResponse(
                                                    authResult.User.Id,
                                                    authResult.User.FirstName,
                                                    authResult.User.LastName,
                                                    authResult.User.Email,
                                                    authResult.Token);

}