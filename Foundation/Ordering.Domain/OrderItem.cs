using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain;

public sealed class OrderItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;

    public string Sku { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}