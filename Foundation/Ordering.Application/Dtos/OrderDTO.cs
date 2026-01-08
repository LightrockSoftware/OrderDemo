using Ordering.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Dtos;

public sealed record OrderDto(
  Guid Id,
  Guid CustomerId,
  DateTime CreatedUtc,
  OrderStatus Status,
  decimal Total)
{
    public static OrderDto FromEntity(Order order)
        => new(
            order.Id,
            order.CustomerId,
            order.CreatedUtc,
            order.Status,
            order.Total
        );
}
