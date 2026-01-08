using Ordering.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Dtos;

public sealed record TenantDTO(
    Guid Id,
    string Name
    )
{
    public static TenantDTO FromEntity(Tenant tenant)
    => new(
        tenant.Id,
        tenant.Name
    );
}
