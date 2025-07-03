using Catalog.Infrastructure.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public interface ICatalogContext
{
    IMongoCollection<ProductBrandEntity> ProductBrands { get; }
}