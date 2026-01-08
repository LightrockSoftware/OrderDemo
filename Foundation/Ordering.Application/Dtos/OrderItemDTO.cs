using Ordering.Domain;


namespace Ordering.Application.Dtos;

public sealed record OrderItemDto(
Guid Id,
Guid OrderId,
string Sku,
int Quantity,
decimal UnitPrice)
{
    public static OrderItemDto FromEntity(OrderItem item)
        => new(
            item.Id,
            item.OrderId,
            item.Sku,
            item.Quantity,
            item.UnitPrice
        );
}
