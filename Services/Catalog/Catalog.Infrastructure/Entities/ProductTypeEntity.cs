using Catalog.Core.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public class ProductTypeEntity : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
}

public static class ProductTypeEntityExtensions
{
    public static ProductType ToProductType(this ProductTypeEntity entity) =>
        new ProductType
        {
            Id = entity.Id,
            Name = entity.Name
        };
}