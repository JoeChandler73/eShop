using Basket.Domain.Model;
using Shared.Mediator;

namespace Basket.Application.Commands;

public record CreateShoppingCartCommand(string UserName, List<ShoppingCartItem> Items) : IRequest<ShoppingCart?>;