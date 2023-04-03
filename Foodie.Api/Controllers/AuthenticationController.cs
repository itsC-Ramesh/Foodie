using Foodie.Application.Authentication.Commands.Register;
using Foodie.Application.Authentication.Queries.Login;
using Foodie.Contracts.Authentication;
using Foodie.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : BaseController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var authResult = await _mediator.Send(command);

        return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)), Problem);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediator.Send(query);

        if (authResult.IsError
            && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);

        return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)), Problem);
    }
}