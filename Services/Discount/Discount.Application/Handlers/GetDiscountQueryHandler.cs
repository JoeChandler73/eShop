using Discount.Application.Queries;
using Discount.Domain.Model;
using Discount.Domain.Repositories;
using Grpc.Core;
using Shared.Mediator;

namespace Discount.Application.Handlers;

public class GetDiscountQueryHandler(
    IDiscountRepository discountRepository) : IRequestHandler<GetDiscountQuery, Coupon>
{
    public async Task<Coupon> Handle(GetDiscountQuery request)
    {
        var coupon = await discountRepository.GetDiscount(request.ProductName);

        if (coupon == null)
        {
            throw new RpcException(
                new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} was not found."));
        }

        return coupon;
    }
}