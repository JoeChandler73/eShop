using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<ProductBrandEntity> ProductBrands { get; }

    public CatalogContext(IOptions<MongoDbSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);
        
        ProductBrands = database.GetCollection<ProductBrandEntity>(options.Value.BrandsCollection);
        
        BrandContextSeed.SeedData(ProductBrands);
    }
}