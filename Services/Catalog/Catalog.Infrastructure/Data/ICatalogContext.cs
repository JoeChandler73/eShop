using Catalog.Infrastructure.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public interface ICatalogContext
{
    IMongoCollection<ProductEntity> Products { get; }
    
    IMongoCollection<ProductBrandEntity> ProductBrands { get; }
    
    IMongoCollection<ProductTypeEntity> ProductTypes { get; }
}