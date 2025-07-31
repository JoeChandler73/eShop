using Basket.Application.Queries;
using Basket.Domain.Model;
using Basket.Domain.Repositories;
using Shared.Mediator;

namespace Basket.Application.Handlers;

public class GetBasketByUserNameHandler(
    IBasketRepository basketRepository) : IRequestHandler<GetBasketByUserNameQuery, ShoppingCart?>
{
    public async Task<ShoppingCart?> Handle(GetBasketByUserNameQuery request)
    {
        var shoppingCart = await basketRepository.GetBasket(request.UserName);
        return shoppingCart;
    }
}