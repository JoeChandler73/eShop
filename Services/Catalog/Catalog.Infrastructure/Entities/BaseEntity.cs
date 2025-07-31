using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public record BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; init; }
}