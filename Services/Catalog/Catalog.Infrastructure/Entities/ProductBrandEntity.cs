using Catalog.Core.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public class ProductBrandEntity : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
}

public static class ProductBrandEntityExtensions
{
    public static ProductBrand ToProductBrand(this ProductBrandEntity entity) =>
        new ProductBrand
        {
            Id = entity.Id,
            Name = entity.Name
        };
}