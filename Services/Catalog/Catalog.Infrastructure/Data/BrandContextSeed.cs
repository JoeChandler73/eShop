using System.Reflection;
using System.Text.Json;
using Catalog.Infrastructure.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class BrandContextSeed
{
    public static void SeedData(IMongoCollection<ProductBrandEntity> brandCollection)
    {
        var checkBrands = brandCollection.Find(x => true).Any();
        if (!checkBrands)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(currentDirectory!, "Data", "SeedData", "brands.json");
            var brandsData = File.ReadAllText(path);
            var brands = JsonSerializer.Deserialize<List<ProductBrandEntity>>(brandsData);
            if (brands != null)
            {
                foreach (var brand in brands)
                    brandCollection.InsertOne(brand);
            }
        }
    }
}