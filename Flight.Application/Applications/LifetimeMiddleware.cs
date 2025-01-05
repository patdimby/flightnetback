using Flight.Infrastructure.Contracts;
using Flight.Infrastructure.Implementations;
using Flight.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Flight.Application.Applications;

/// <summary>
///     The repository service.
/// </summary>
public static class LifetimeMiddleware
{
    /// <summary>
    ///     Adds the repository service.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddRepoService(this IServiceCollection services)
    {
        services.AddScoped<ILoggerManager, LoggerManager>();
        services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddSingleton<IMemoryCache, MemoryCache>();
    }
}