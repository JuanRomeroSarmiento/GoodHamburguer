using Domain.Menus;
using Domain.Orders;
using Infrastructure.Caching;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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

        services.AddMemoryCache();

        services.AddScoped<IMenuRepository>(provider =>
        {
            var context = provider.GetService<ApplicationWriteDbContext>();
            var cache = provider.GetService<IMemoryCache>();

            return new CachingMenuRepository(
                new MenuRepository(context),
                cache);
        });
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
