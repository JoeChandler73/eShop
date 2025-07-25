using Orders.Application.Commands;
using Orders.Application.Events;
using Shared.Mediator;
using Shared.Messaging;

namespace Orders.Api.Services;

public class MessageBusService(
    IMessageBus messageBus,
    IMediator mediator,
    ILogger<MessageBusService> logger) 
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        messageBus.Subscribe<BasketCheckoutEvent>(HandleBasketCheckout);
        await messageBus.InitialiseAsync();
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await messageBus.DisposeAsync();
        
        await base.StopAsync(stoppingToken);
    }

    private async Task HandleBasketCheckout(BasketCheckoutEvent @event)
    {
        logger.LogInformation("BasketCheckout event received");

        var command = new CheckoutOrderCommand
        {
            UserName = @event.UserName,
            TotalPrice = @event.TotalPrice,
            FirstName = @event.FirstName,
            LastName = @event.LastName,
            EmailAddress = @event.EmailAddress,
            AddressLine = @event.AddressLine,
            Country = @event.Country,
            State = @event.State,
            ZipCode = @event.ZipCode,
            CardName = @event.CardName,
            CardNumber = @event.CardNumber,
            Expiration = @event.Expiration,
            Cvv = @event.Cvv,
            PaymentMethod = @event.PaymentMethod
        };
        
        var result = await mediator.Send(command);
        
        logger.LogInformation("BasketCheckout event processed");
    }
}