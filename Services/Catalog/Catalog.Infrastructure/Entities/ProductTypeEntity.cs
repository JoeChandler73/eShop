using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public class ProductTypeEntity : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
}