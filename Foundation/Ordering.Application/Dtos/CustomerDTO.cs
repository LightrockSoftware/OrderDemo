using Ordering.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Dtos;

public sealed record CustomerDto(
    Guid Id,
    Guid TenantId,
    string Name)
{
    public static CustomerDto FromEntity(Customer customer)
        => new(
            customer.Id,
            customer.TenantId,
            customer.Name
        );
}
