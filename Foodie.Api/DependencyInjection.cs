using Foodie.Api.Common.Errors;
using Foodie.Api.Common.Mappings;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Foodie.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddControllers();

        //Custom Problem Details Factory
        services.AddSingleton<ProblemDetailsFactory, FoodieProblemDetailsFactory>();

        return services;
    }
}

