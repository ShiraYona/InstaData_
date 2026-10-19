using InstaData.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaData.Infrastructure;

/// <summary>
/// Composition root for the Infrastructure layer.
/// Registration of repositories and external services belongs here.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' was not found in configuration.");

        services.AddDbContext<InstaDataDbContext>(options =>
            options.UseSqlServer(connectionString));

        // TODO: register repositories, e.g.
        // services.AddScoped<IExampleRepository, ExampleRepository>();

        return services;
    }
}
