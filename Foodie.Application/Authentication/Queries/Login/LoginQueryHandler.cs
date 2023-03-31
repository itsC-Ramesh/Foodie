using ErrorOr;
using Foodie.Application.Common.Interfaces.Authentication;
using Foodie.Application.Common.Interfaces.Persistance;
using Foodie.Domain.Common.Errors;
using MediatR;

namespace Foodie.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetUserByEmail(query.Email);

        //Validate User
        if (user == null) return Errors.Authentication.InvalidCredentials;

        //Validate password
        if (query.Password != user.Password) return Errors.Authentication.InvalidCredentials;

        //Generate Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        //Return AuthResult
        return new AuthenticationResult(user, token);
    }
}
