using ErrorOr;
using Foodie.Application.Common.Interfaces.Authentication;
using Foodie.Application.Common.Interfaces.Persistance;
using Foodie.Domain.Common.Errors;
using Foodie.Domain.Entities;
using MediatR;


namespace Foodie.Application.Authentication.Commands.Register;

internal class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = _userRepository.GetUserByEmail(command.Email);
        if (user != null)
        {
            return Errors.User.DuplicateEmail;
        }

        //Create & Register User
        user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        //Generate JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token); ;
    }
}
