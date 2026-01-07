using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // DbContext is registered in the API using AddNpgsqlDbContext via Aspire.
        return services;
    }
}
