using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Orders.Domain.Entities;
using Orders.Infrastructure.Extensions;

namespace Orders.Infrastructure.Data;

public sealed class OrderContext : DbContext
{
    public OrderContext(DbContextOptions options) : base(options)
    {
        if (Database.GetService<IDatabaseCreator>() is not RelationalDatabaseCreator databaseCreator) 
            return;
        
        if(!databaseCreator.CanConnect())
            databaseCreator.Create();
            
        if(!databaseCreator.HasTables())
            databaseCreator.CreateTables();
    }
    
    public DbSet<Order> Orders { get; set; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                case EntityState.Modified:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "joe";
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = "joe";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
        modelBuilder.Seed();
    }
}

