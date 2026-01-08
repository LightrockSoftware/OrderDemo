using Ordering.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ordering.Application.Dtos;

public sealed record OrderSummaryDto(
    Guid Id,
    DateTime CreatedUtc,
    OrderStatus Status,
    string Customer,
    int ItemCount,
    decimal Total)
{
        public static Expression<Func<Order, OrderSummaryDto>> Projection
            => o => new OrderSummaryDto(
                o.Id,
                o.CreatedUtc,
                o.Status,
                o.Customer.Name,
                o.Items.Count,
                o.Items.Sum(i => i.Quantity * i.UnitPrice)
            );
}

