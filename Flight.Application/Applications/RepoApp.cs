using Flight.Infrastructure.Contracts;
using Flight.Infrastructure.Implementations;
using Flight.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Flight.Application.Applications;

/// <summary>
///     The repository service.
/// </summary>
public static class RepoApp
{
    /// <summary>
    ///     Adds the repository service.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddRepoService(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}