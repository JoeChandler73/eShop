namespace Catalog.Infrastructure.Settings;

public record MongoDbSettings
{
    public string ConnectionString { get; init; }
    public string DatabaseName { get; init; }
    
    public string ProductsCollection { get; init; }
    public string BrandsCollection { get; init; }
    public string TypesCollection { get; init; }
}