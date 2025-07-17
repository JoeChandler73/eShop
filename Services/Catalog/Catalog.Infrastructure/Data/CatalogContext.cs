using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<ProductEntity> Products { get; }
    
    public IMongoCollection<ProductBrandEntity> ProductBrands { get; }
    
    public IMongoCollection<ProductTypeEntity> ProductTypes { get; }

    public CatalogContext(
        IMongoDatabase database,
        IOptions<MongoDbSettings> options)
    {
        Products = database.GetCollection<ProductEntity>(options.Value.ProductsCollection);
        ProductBrands = database.GetCollection<ProductBrandEntity>(options.Value.BrandsCollection);
        ProductTypes = database.GetCollection<ProductTypeEntity>(options.Value.TypesCollection);
        
        ProductContextSeed.SeedData(Products);
        BrandContextSeed.SeedData(ProductBrands);
        TypeContextSeed.SeedData(ProductTypes);
    }
}