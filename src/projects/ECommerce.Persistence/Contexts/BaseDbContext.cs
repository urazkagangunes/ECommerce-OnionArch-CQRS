using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using System.Reflection;
using Core.Security.Entities;

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
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }

    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

}
