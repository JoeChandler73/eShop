using Basket.Application.Queries;
using Basket.Domain.Repositories;
using Basket.Infrastructure.Repositories;
using Shared.Mediator;

namespace Basket.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetValue<string>("RedisSettings:ConnectionString");
        });
        
        builder.Services.AddMediator(typeof(GetBasketByUserNameQuery).Assembly);
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
    }
}