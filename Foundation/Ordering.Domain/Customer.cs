using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain;

public sealed class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = default!;

    public string Name { get; set; } = default!;
}

