using Basket.Domain.Repositories;
using Basket.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Basket.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurePersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetValue<string>("RedisSettings:ConnectionString");
        });
        
        services.AddScoped<IBasketRepository, BasketRepository>();
        
        services.AddHealthChecks().AddRedis(
            configuration["RedisSettings:ConnectionString"],
            "RedisHealth",
            HealthStatus.Degraded);
    }
}