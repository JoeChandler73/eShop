using Basket.Application.Commands;
using Basket.Domain.Model;
using Basket.Domain.Repositories;
using Shared.Mediator;

namespace Basket.Application.Handlers;

public class CreateShoppingCartHandler(
    IBasketRepository basketRepository) : IRequestHandler<CreateShoppingCartCommand, ShoppingCart>
{
    public async Task<ShoppingCart> Handle(CreateShoppingCartCommand request)
    {
        var shoppingCart = await basketRepository.UpdateBasket(new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items
        });
        
        return shoppingCart;
    }
}