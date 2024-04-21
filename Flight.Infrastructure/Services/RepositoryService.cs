using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Repositories;
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
        services.AddScoped<IGenericRepository<Airline>, GenericRepository<Airline>>()
            .AddScoped<IGenericRepository<Airport>, GenericRepository<Airport>>()
            .AddScoped<IGenericRepository<Booking>, GenericRepository<Booking>>()
            .AddScoped<IGenericRepository<City>, GenericRepository<City>>()
            .AddScoped<IGenericRepository<Country>, GenericRepository<Country>>()
            .AddScoped<IGenericRepository<Domain.Entities.Flight>, GenericRepository<Domain.Entities.Flight>>()
            .AddScoped<IGenericRepository<Passenger>, GenericRepository<Passenger>>()
            .AddScoped<IGenericRepository<Vehicle>, GenericRepository<Vehicle>>();
    }
}