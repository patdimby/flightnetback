using Flight.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flight.Infrastructure.Services;

/// <summary>
///     The database service.
/// </summary>
public static class DatabaseService
{
    /// <summary>
    ///     The add data context.
    /// </summary>
    public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FlightContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString")));
    }
}