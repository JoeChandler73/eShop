using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Infrastructure.Data;

namespace Orders.Infrastructure.Repositories;

public class Repository<TEntity>(IDbContextFactory<OrderContext> factory) : IRepository<TEntity> where TEntity : Entity
{
    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await using var context = await factory.CreateDbContextAsync();
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
    }
}