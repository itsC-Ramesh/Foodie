using Foodie.Domain.Entities;

namespace Foodie.Application.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}