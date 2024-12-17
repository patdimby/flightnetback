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
        var connString = configuration.GetConnectionString("DbConn");
        services.AddDbContext<FlightContext>(opt =>
            opt.UseMySql(connString, ServerVersion.AutoDetect(connString)));
    }

    public static void AddDataContext(this IServiceCollection services)
    {
        var connString = "server=127.0.0.1; port=3306; user=root; password=Ma$terkey1; database=flights";
        services.AddDbContext<FlightContext>(opt =>
            opt.UseMySql(connString, ServerVersion.AutoDetect(connString)));
    }
}