using Discount.Domain.Model;
using Shared.Mediator;

namespace Discount.Application.Queries;

public record GetDiscountQuery(string ProductName) : IRequest<Coupon>;