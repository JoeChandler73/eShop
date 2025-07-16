using Basket.Api.Services;
using Basket.Application.Queries;
using Basket.Domain.Repositories;
using Basket.Infrastructure.Repositories;
using Shared.Mediator;
using Shared.Messaging;
using Shared.Messaging.Infrastructure;

namespace Basket.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMq"));
        builder.Services.AddSingleton<IMessageSerializer, JsonMessageSerialzer>();
        builder.Services.AddSingleton<IMessageBus, RabbitMqMessageBus>();
        builder.Services.AddHostedService<MessageBusService>();
        
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetValue<string>("RedisSettings:ConnectionString");
        });
        
        builder.Services.AddMediator(typeof(GetBasketByUserNameQuery).Assembly);
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
    }
}