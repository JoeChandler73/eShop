using Discount.Application.Queries;
using Discount.Domain.Model;
using Discount.Domain.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using Shared.Mediator;

namespace Discount.Application.Handlers;

public class GetDiscountQueryHandler(
    IDiscountRepository discountRepository) : IRequestHandler<GetDiscountQuery, CouponModel>
{
    public async Task<CouponModel> Handle(GetDiscountQuery request)
    {
        var coupon = await discountRepository.GetDiscount(request.ProductName);

        if (coupon == null)
        {
            throw new RpcException(
                new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} was not found."));
        }

        var couponModel = new CouponModel
        {
            Id = coupon.Id,
            Amount = coupon.Amount,
            Description = coupon.Description,
            ProductName = coupon.ProductName
        };
        
        return couponModel;
    }
}