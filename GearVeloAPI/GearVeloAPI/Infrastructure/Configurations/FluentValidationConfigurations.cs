using FluentValidation;
using FluentValidation.AspNetCore;

namespace GearVeloAPI.Infrastructure.Configurations;

public static class FluentValidationConfigurations
{
    public static void ConfigureFluentValidatios
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Program>();
    }
}