using Shared.Messaging;

namespace Basket.Api.Services;

public class MessageBusService(IMessageBus messageBus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await messageBus.InitialiseAsync();
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await messageBus.DisposeAsync();
        
        await base.StopAsync(stoppingToken);
    }
}