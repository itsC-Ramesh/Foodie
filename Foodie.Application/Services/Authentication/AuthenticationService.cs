using ErrorOr;
using Foodie.Application.Common.Interfaces.Authentication;
using Foodie.Application.Common.Interfaces.Persistance;
using Foodie.Domain.Common.Errors;
using Foodie.Domain.Entities;

namespace Foodie.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists
        var user = _userRepository.GetUserByEmail(email);
        if (user != null)
        {
            return Errors.User.DuplicateEmail;
        }

        //Create & Register User
        user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //Generate JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);

        //Validate User
        if (user == null) return Errors.Authentication.InvalidCredentials;

        //Validate password
        if (password != user.Password) return Errors.Authentication.InvalidCredentials;

        //Generate Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        //Return AuthResult
        return new AuthenticationResult(user, token);
    }


}