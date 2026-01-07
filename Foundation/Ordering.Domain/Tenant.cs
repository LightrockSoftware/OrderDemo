using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain;

public sealed class Tenant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
}
