using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Infrastructure.Data;
using Orders.Infrastructure.Repositories;

namespace Orders.Infrastructure.Extensions;

public static class Extensions
{
    public static IServiceCollection ConfigurePersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<OrderContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("OrderingConnectionString")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        return services;
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        var now = DateTime.UtcNow;
        
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                UserName = "jic",
                FirstName = "Joe",
                LastName = "Chandler",
                EmailAddress = "joe@test.com",
                AddressLine = "The Chine",
                Country = "UNited Kingdom",
                TotalPrice = 100,
                State = "WEst Sussex",
                ZipCode = "BN14111",
                CardName = "Visa",
                CardNumber = "1234567890123456",
                CreatedBy = "Joe",
                CreatedDate = now,
                Expiration = "12/30",
                Cvv = "123",
                PaymentMethod = 1,
                LastModifiedBy = "Joe",
                LastModifiedDate = now
            });
    }
}