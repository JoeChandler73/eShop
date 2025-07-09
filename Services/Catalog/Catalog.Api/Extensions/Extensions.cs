using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Settings;
using Shared.Mediator;

namespace Catalog.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
        builder.Services.AddMediator(typeof(GetAllTypesQuery).Assembly);
        builder.Services.AddScoped<ICatalogContext, CatalogContext>();
        builder.Services.AddScoped<IBrandRepository, ProductRepository>();
        builder.Services.AddScoped<ITypesRepository, ProductRepository>();
    }
}