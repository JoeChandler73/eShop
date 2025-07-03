using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Settings;

namespace Catalog.Api.Extensions;

public static class Extensions
{
    public static void ConfigureServices(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
        builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetAllBrandsQuery).Assembly));
        builder.Services.AddAutoMapper(typeof(ProductBrandEntity));
        builder.Services.AddScoped<ICatalogContext, CatalogContext>();
        builder.Services.AddScoped<IBrandRepository, ProductRepository>();
    }
}