using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Infrastructure.Data;

namespace Orders.Infrastructure.Repositories;

public class OrderRepository(IDbContextFactory<OrderContext> factory) : Repository<Order>(factory), IOrderRepository
{
    private readonly IDbContextFactory<OrderContext> _factory = factory;

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        await using var context = await _factory.CreateDbContextAsync();
        
        var orders = await context.Orders
            .Where(o => o.UserName == userName)
            .ToListAsync();
        
        return orders;
    }
}