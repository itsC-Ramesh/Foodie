using Foodie.Domain.Entities;

namespace Foodie.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}