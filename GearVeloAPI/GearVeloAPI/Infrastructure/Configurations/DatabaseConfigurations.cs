using GearVeloAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace GearVeloAPI.Infrastructure.Configurations;

public static class DatabaseConfigurations
{
    public static void ConfigureDatabase
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(o =>
        {
            o.UseSqlServer(configuration.GetConnectionString("Eshqin-PC"));
        });
    }
}