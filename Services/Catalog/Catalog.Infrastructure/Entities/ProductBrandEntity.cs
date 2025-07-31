using Catalog.Core.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public record ProductBrandEntity : BaseEntity
{
    [BsonElement("Name")]
    public required string Name { get; init; }
}

public static class ProductBrandEntityExtensions
{
    public static ProductBrand ToProductBrand(this ProductBrandEntity entity) =>
        new()
        {
            Id = entity.Id,
            Name = entity.Name
        };

    public static ProductBrandEntity ToProductBrandEntity(this ProductBrand productBrand) =>
        new()
        {
            Id = string.IsNullOrWhiteSpace(productBrand.Id) ? ObjectId.GenerateNewId().ToString() : productBrand.Id,
            Name = productBrand.Name
        };
}