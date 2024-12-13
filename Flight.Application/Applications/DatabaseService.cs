using Flight.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flight.Application.Applications;

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
        var connString = configuration.GetSection("DbConn").Value;
        services.AddDbContext<FlightContext>(opt =>
            opt.UseMySql(connString, ServerVersion.AutoDetect(connString)));
    }
}