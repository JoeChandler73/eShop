namespace Catalog.Infrastructure.Settings;

public record MongoDbSettings
{
    public required string ConnectionString { get; init; }
    public required string DatabaseName { get; init; }
    public required string ProductsCollection { get; init; }
    public required string BrandsCollection { get; init; }
    public required string TypesCollection { get; init; }
}