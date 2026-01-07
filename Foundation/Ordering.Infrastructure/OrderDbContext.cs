using Microsoft.EntityFrameworkCore;
using Ordering.Domain;

namespace Ordering.Infrastructure;

public sealed class OrderingDbContext : DbContext
{
    public OrderingDbContext(DbContextOptions<OrderingDbContext> options) : base(options) { }

    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tenant>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Customer>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Customer>()
            .HasOne(x => x.Tenant)
            .WithMany()
            .HasForeignKey(x => x.TenantId);

        modelBuilder.Entity<Order>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        modelBuilder.Entity<OrderItem>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<OrderItem>()
            .HasOne(x => x.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(x => x.OrderId);
    }
}
