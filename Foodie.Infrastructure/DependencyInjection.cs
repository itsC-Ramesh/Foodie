using Foodie.Application.Common.Interfaces.Authentication;
using Foodie.Application.Common.Interfaces.Persistance;
using Foodie.Application.Common.Interfaces.Services;
using Foodie.Infrastructure.Authentication;
using Foodie.Infrastructure.Persistance;
using Foodie.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();


        return services;
    }
}

