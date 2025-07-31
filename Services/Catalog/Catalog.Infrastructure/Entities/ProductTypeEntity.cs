using Catalog.Core.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public class ProductTypeEntity : BaseEntity
{
    [BsonElement("Name")]
    public required string Name { get; init; }
}

public static class ProductTypeEntityExtensions
{
    public static ProductType ToProductType(this ProductTypeEntity entity) =>
        new ProductType
        {
            Id = entity.Id,
            Name = entity.Name
        };

    public static ProductTypeEntity ToProductTypeEntity(this ProductType productType) =>
        new ProductTypeEntity
        {
            Id = productType.Id,
            Name = productType.Name
        };
}