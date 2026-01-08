using Microsoft.EntityFrameworkCore;
using Ordering.Application.Dtos;
using Ordering.Infrastructure;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registers DbContext + pooling + health checks + telemetry using Aspire integration.
builder.Services.AddDbContext<OrderingDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("orderingdb");
    options.UseNpgsql(cs, npgoptions => npgoptions.MigrationsHistoryTable("__EFMigrationsHistory", "ordering"));
});


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrderingDbContext>();
    db.Database.Migrate();
}

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Minimal “seed” endpoint for day-1 demo
app.MapPost("/seed", async (OrderingDbContext db) =>
{
    if (await db.Tenants.AnyAsync()) return Results.Ok("Already seeded.");

    var tenant = new Ordering.Domain.Tenant { Name = "Demo Tenant" };
    var customer = new Ordering.Domain.Customer { Name = "Demo Customer", Tenant = tenant };

    var order = new Ordering.Domain.Order { Customer = customer, Status = Ordering.Domain.OrderStatus.Submitted };
    order.Items.Add(new Ordering.Domain.OrderItem { Sku = "WP-CAP-001", Quantity = 2, UnitPrice = 12.50m });
    order.Items.Add(new Ordering.Domain.OrderItem { Sku = "WP-BALL-002", Quantity = 1, UnitPrice = 29.99m });

    db.Add(order);
    await db.SaveChangesAsync();

    return Results.Ok("Seeded.");
});

app.MapGet("/tenants/{tenantId:guid}/orders", async (Guid tenantId, OrderingDbContext db) =>
{
    // This query will become VERY relevant in later posts (expression trees + translation).
    var orders = await db.Orders
        .Where(o => o.Customer.TenantId == tenantId)
        .Select(OrderSummaryDto.Projection)
        .ToListAsync();

    return Results.Ok(orders);
});

app.MapGet("/tenants/demo", async (OrderingDbContext db) =>
{
    var tenantId = await db.Tenants
        .Select(t => t.Id)
        .FirstOrDefaultAsync();

    return tenantId == Guid.Empty
        ? Results.NotFound()
        : Results.Ok(tenantId);
});


app.Run();
