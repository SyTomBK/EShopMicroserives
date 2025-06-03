
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;
public static class DependenceInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependenceInjection).Assembly));

        //services.AddScoped<IOrderRepository, OrderRepository>();
        //services.AddScoped<IOrderService, OrderService>();
        //services.AddScoped<IValidator<Order>, OrderValidator>();
        return services;
    }
}
