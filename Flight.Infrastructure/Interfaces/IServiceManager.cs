using Flight.Domain.Entities;

namespace Flight.Infrastructure.Interfaces;

public interface IServiceManager
{
    IBaseService<Airline> AirlineService { get; }
    IBaseService<Airport> AirportService { get; }
    IBaseService<Booking> BookingService { get; }
    IBaseService<City> CityService { get; }
    IBaseService<Country> CountryService { get; }
    IBaseService<Domain.Entities.Flight> FlightService { get; }
    IBaseService<Passenger> PassengerService { get; }
    IBaseService<Vehicle> VehicleService { get; }
}