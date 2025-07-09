using System.Reflection;
using System.Text.Json;
using Catalog.Infrastructure.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class TypeContextSeed
{
    public static void SeedData(IMongoCollection<ProductTypeEntity> typeCollection)
    {
        var checkTypes = typeCollection.Find(x => true).Any();
        if (!checkTypes)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(currentDirectory!, "Data", "SeedData", "types.json");
            var typesData = File.ReadAllText(path);
            var types = JsonSerializer.Deserialize<List<ProductTypeEntity>>(typesData);
            if (types != null)
            {
                foreach (var type in types)
                    typeCollection.InsertOne(type);
            }
        }
    }
}