using Microsoft.Extensions.DependencyInjection;

namespace Flight.Application.Services;

/// <summary>
///     The application service.
/// </summary>
public static class ApplicationService
{
    /// <summary>
    ///     Adds the applications.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddApplications(this IServiceCollection services)
    {
        //services.AddScoped<IGenericApplication, CityApplication>();
    }
}