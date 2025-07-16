using Basket.Application.Commands;
using Basket.Application.GrpcService;
using Basket.Domain.Model;
using Basket.Domain.Repositories;
using Shared.Mediator;

namespace Basket.Application.Handlers;

public class CreateShoppingCartHandler(
    IBasketRepository basketRepository,
    DiscountGrpcService discountGrpcService) 
    : IRequestHandler<CreateShoppingCartCommand, ShoppingCart>
{
    public async Task<ShoppingCart> Handle(CreateShoppingCartCommand request)
    {
        foreach (var item in request.Items)
        {
            var coupon = await discountGrpcService.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }
        
        var shoppingCart = await basketRepository.UpdateBasket(new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items
        });
        
        return shoppingCart;
    }
}