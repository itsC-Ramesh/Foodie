using Foodie.Application.Authentication;
using Foodie.Application.Authentication.Commands.Register;
using Foodie.Application.Authentication.Queries.Login;
using Foodie.Contracts.Authentication;
using Mapster;

namespace Foodie.Api.Common.Mappings;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegistrationRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}
