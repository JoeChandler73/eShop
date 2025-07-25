using Orders.Domain.Entities;

namespace Orders.Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}