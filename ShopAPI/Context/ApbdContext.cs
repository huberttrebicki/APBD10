using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Context;

public class ApbdContext : DbContext
{
    public ApbdContext(){}
    
    public ApbdContext(DbContextOptions<ApbdContext> options) : base(options){}
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductCategory>().HasKey(pc => new { pc.IdProduct, pc.IdCategory });
        builder.Entity<ShoppingCart>().HasKey(sc => new { sc.IdAccount, sc.IdProduct });
    }
}