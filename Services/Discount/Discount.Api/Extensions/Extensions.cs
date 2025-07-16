using Discount.Application.Queries;
using Discount.Domain.Repositories;
using Discount.Infrastructure.Repositories;
using Shared.Mediator;

namespace Discount.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddGrpc();
        builder.Services.AddMediator(typeof(GetDiscountQuery).Assembly);
        builder.Services.AddSingleton<IDiscountRepository, DiscountRepository>();
    }
}