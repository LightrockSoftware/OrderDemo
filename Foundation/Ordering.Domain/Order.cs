namespace Ordering.Domain;

public enum OrderStatus { Draft, Submitted, Paid, Shipped, Cancelled }

public sealed class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;

    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public OrderStatus Status { get; set; } = OrderStatus.Draft;

    public List<OrderItem> Items { get; set; } = new();

    public decimal Total => Items.Sum(i => i.Quantity * i.UnitPrice);
}
