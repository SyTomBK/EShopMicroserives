
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependenceInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register infrastructure services here
        // Example: services.AddScoped<IOrderRepository, OrderRepository>();

        var connectionString = configuration.GetConnectionString("Database");

        return services;
    }
}
