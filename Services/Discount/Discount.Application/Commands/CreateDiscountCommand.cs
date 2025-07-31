using Discount.Domain.Model;
using Shared.Mediator;

namespace Discount.Application.Commands;

public record CreateDiscountCommand : IRequest<Coupon>
{
    public required string ProductName { get; init; }
    
    public required string Description { get; init; }
    
    public required int Amount { get; init; }
}