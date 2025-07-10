using System.Reflection;
using System.Text.Json;
using Catalog.Infrastructure.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class ProductContextSeed
{
    public static void SeedData(IMongoCollection<ProductEntity> productCollection)
    {
        var checkProducts = productCollection.Find(filter => true).Any();
        if (!checkProducts)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(currentDirectory!, "Data", "SeedData", "products.json");
            var productsData = File.ReadAllText(path);
            var products = JsonSerializer.Deserialize<List<ProductEntity>>(productsData);
            if (products != null)
            {
                foreach (var product in products)
                    productCollection.InsertOne(product);
            }
        }
    }
}