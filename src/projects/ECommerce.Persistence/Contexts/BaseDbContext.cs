using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using System.Reflection;

namespace ECommerce.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> opt) : base(opt)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder); // EF Core'un varsayılan davranışlarını uygula
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.Entity<User>
    }

    public DbSet<Category> Categories { get; set; }
}
