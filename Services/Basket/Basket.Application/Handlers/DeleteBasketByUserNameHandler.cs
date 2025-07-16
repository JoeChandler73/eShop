using Basket.Application.Commands;
using Basket.Domain.Repositories;
using Shared.Mediator;

namespace Basket.Application.Handlers;

public class DeleteBasketByUserNameHandler(
    IBasketRepository basketRepository) 
    : IRequestHandler<DeleteBasketByUserNameCommand>
{
    public async Task<bool> Handle(DeleteBasketByUserNameCommand request)
    {
        await basketRepository.DeleteBasket(request.UserName);
        return true;
    }
}