using GearVeloAPI.Options;

namespace GearVeloAPI.Infrastructure.Configurations;

public static class OptionConfigurations
{
    public static void ConfigureOptions
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailConfigOptions>
            (configuration.GetSection(nameof(EmailConfigOptions)));
    }
}