namespace tech_test_payment_api.Infrastructure.Context;

using System.Reflection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

internal class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {
    }

    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
