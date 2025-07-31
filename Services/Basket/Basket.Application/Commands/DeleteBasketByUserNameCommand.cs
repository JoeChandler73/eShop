using Shared.Mediator;

namespace Basket.Application.Commands;

public record DeleteBasketByUserNameCommand(string UserName) : IRequest;