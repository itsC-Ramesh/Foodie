using Foodie.Application.Services.Authentication;
using Foodie.Contracts.Authentication;
using Foodie.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : BaseController
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegistrationRequest request)
    {
        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token
                );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(request.Email, request.Password);

        if (authResult.IsError
            && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);

        return authResult.Match(authResult => Ok(MapAuthResult(authResult)), Problem);
    }

}