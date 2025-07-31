using Discount.Domain.Model;
using Discount.Grpc.Protos;

namespace Discount.Api.Extensions;

public static class CouponModelExtensions
{
    public static CouponModel ToCouponModel(this Coupon coupon)
    {
        return new CouponModel
        {
            Id = coupon.Id ?? 0,
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = coupon.Amount
        };
    }
}