using Domain.Menus;
using Domain.Orders;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
        });

        services.AddDbContext<ApplicationReadDbContext>(
            options => options
                .UseSqlite(configuration.GetConnectionString("GoodHamburguer"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddDbContext<ApplicationWriteDbContext>(
            options => options
                .UseSqlite(configuration.GetConnectionString("GoodHamburguer")));

        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
