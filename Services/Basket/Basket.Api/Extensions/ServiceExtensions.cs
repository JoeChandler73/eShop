using Basket.Api.Services;
using Basket.Application.GrpcService;
using Basket.Application.Queries;
using Basket.Infrastructure.Extensions;
using Discount.Grpc.Protos;
using Shared.Mediator;
using Shared.Messaging;
using Shared.Messaging.Infrastructure;

namespace Basket.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureMessageBus(configuration);
        services.AddHostedService<MessageBusService>();
        services.ConfigureDiscountService(configuration);
        services.ConfigurePersistance(configuration);
        services.AddMediator(typeof(GetBasketByUserNameQuery).Assembly);
        
        return services;
    }

    private static IServiceCollection ConfigureDiscountService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DiscountGrpcService>();
        services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
            options.Address = new Uri(configuration["GrpcSettings:DiscountUrl"]));
        
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