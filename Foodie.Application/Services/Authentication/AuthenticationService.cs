using Foodie.Application.Common.Interfaces.Authentication;
using Foodie.Application.Common.Interfaces.Persistance;
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
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists
        var user = _userRepository.GetUserByEmail(email);
        if (user != null)
        {
            throw new Exception("User with given name already exists");
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

    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);

        //Validate User
        if (user == null) throw new Exception("Invalid Email");

        //Validate password
        if (password != user.Password) throw new Exception("Invalid Password");

        //Generate Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        //Return AuthResult
        return new AuthenticationResult(user, token);
    }


}