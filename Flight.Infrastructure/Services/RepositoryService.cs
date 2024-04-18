using Microsoft.Extensions.DependencyInjection;

namespace Flight.Infrastructure.Services;

/// <summary>
///     The repository service.
/// </summary>
public static class RepositoryService
{
    /// <summary>
    ///     Adds the repository service.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddRepoService(this IServiceCollection services)
    {
        //services.AddScoped<GenericRepository<Vehicle>, IGenericRepository<Vehicle>>();
    }
}