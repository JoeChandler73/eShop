using Orders.Api.Services;
using Orders.Application.Queries;
using Orders.Infrastructure.Extensions;
using Shared.Mediator;
using Shared.Messaging;
using Shared.Messaging.Infrastructure;

namespace Orders.Api.Extensions;

public static class Extensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureMessageBus(configuration);
        services.AddHostedService<MessageBusService>();
        services.AddMediator(typeof(GetOrderListQuery).Assembly);
        services.ConfigurePersistance(configuration);
        
        return services;
    }
    
    private static IServiceCollection ConfigureMessageBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqOptions>(configuration.GetSection("RabbitMq"));
        services.AddSingleton<IMessageSerializer, JsonMessageSerialzer>();
        services.AddSingleton<IMessageBus, RabbitMqMessageBus>();
        
        return services;
    }
}