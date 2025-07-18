using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using Shared.Mediator;

namespace Discount.Api.Services;

public class DiscountService(
    IMediator mediator,
    ILogger<DiscountService> logger) 
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var query = new GetDiscountQuery(request.ProductName);
        var result = await mediator.Send(query);
        
        logger.LogInformation($"Discount is retrieved for the Product Name: {request.ProductName} and Amount : {result.Amount}");
        
        return result;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var command = new CreateDiscountCommand
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };
        
        var result = await mediator.Send(command);
        
        logger.LogInformation($"Discount is successfully created for the Product Name: {result.ProductName}");
        
        return result;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var command = new UpdateDiscountCommand
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };
        
        var result = await mediator.Send(command);
        
        logger.LogInformation($"Discount is successfully updated for the Product Name: {result.ProductName}");
        
        return result;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request,
        ServerCallContext context)
    {
        var command = new DeleteDiscountCommand(request.ProductName);
        var delete = await mediator.Send(command);

        logger.LogInformation($"Discount is successfully deleted for the Product Name: {request.ProductName}");

        var response = new DeleteDiscountResponse
        {
            Success = delete
        };
        
        return response;
    }
}