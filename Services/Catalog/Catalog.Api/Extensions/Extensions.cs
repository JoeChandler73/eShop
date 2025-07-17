using Catalog.Application.Queries;
using Catalog.Infrastructure.Extensions;
using Shared.Mediator;

namespace Catalog.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediator(typeof(GetAllTypesQuery).Assembly);
        builder.Services.ConfigurePersistance(builder.Configuration);
    }
}