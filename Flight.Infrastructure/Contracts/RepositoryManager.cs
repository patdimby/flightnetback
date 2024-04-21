using System;
using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Data;
using Flight.Infrastructure.Interfaces;

namespace Flight.Infrastructure.Contracts;

public sealed class RepositoryManager(FlightContext repositoryContext) : IRepositoryManager
{
    private readonly Lazy<IGenericRepository<Airline>> _airlineRepository = new(() => new
        AirlineRepository(repositoryContext));

    private readonly Lazy<IGenericRepository<Airport>> _airportRepository = new(() => new
        AirportRepository(repositoryContext));

    private readonly Lazy<IGenericRepository<Booking>> _bookingRepository = new(() => new
        BookingRepository(repositoryContext));

    private readonly Lazy<IGenericRepository<City>> _cityRepository = new(() => new
        CityRepository(repositoryContext));

    private readonly Lazy<IGenericRepository<Country>> _countryRepository = new(() => new
        CountryRepository(repositoryContext));

    private readonly Lazy<IGenericRepository<Domain.Entities.Flight>> _flightRepository = new(() => new
        FlightRepository(repositoryContext));

    private readonly Lazy<IGenericRepository<Passenger>> _passengerRepository = new(() => new
        PassengerRepository(repositoryContext));

    private readonly Lazy<IGenericRepository<Vehicle>> _vehicleRepository = new(() => new
        VehicleRepository(repositoryContext));

    public IGenericRepository<Airline> Airline => _airlineRepository.Value;
    public IGenericRepository<Airport> Airport => _airportRepository.Value;
    public IGenericRepository<Booking> Booking => _bookingRepository.Value;
    public IGenericRepository<City> City => _cityRepository.Value;
    public IGenericRepository<Country> Country => _countryRepository.Value;
    public IGenericRepository<Domain.Entities.Flight> Flight => _flightRepository.Value;
    public IGenericRepository<Passenger> Passenger => _passengerRepository.Value;
    public IGenericRepository<Vehicle> Vehicle => _vehicleRepository.Value;

    public void Save()
    {
        repositoryContext.SaveChanges();
    }
}