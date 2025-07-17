using Catalog.Application.Queries;
using Catalog.Infrastructure.Extensions;
using Shared.Mediator;

namespace Catalog.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediator(typeof(GetAllTypesQuery).Assembly);
        services.ConfigurePersistance(configuration);
        
        return services;
    }
}