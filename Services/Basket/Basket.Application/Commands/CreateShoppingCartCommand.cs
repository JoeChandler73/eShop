using Basket.Domain.Model;
using Shared.Mediator;

namespace Basket.Application.Commands;

public class CreateShoppingCartCommand : IRequest<ShoppingCart>
{
    public CreateShoppingCartCommand(string userName, List<ShoppingCartItem> items)
    {
        UserName = userName;
        Items = items;
    }
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; }
}