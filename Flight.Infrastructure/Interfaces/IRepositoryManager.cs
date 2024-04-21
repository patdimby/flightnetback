using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Contracts;
using Flight.Infrastructure.Data;

namespace Flight.Infrastructure.Interfaces;

public class AirlineRepository(FlightContext context) : GenericRepository<Airline>(context);

public class AirportRepository(FlightContext context) : GenericRepository<Airport>(context);

public class BookingRepository(FlightContext context) : GenericRepository<Booking>(context);

public class CityRepository(FlightContext context) : GenericRepository<City>(context);

public class CountryRepository(FlightContext context) : GenericRepository<Country>(context);

public class FlightRepository(FlightContext context) : GenericRepository<Domain.Entities.Flight>(context);

public class PassengerRepository(FlightContext context) : GenericRepository<Passenger>(context);

public class VehicleRepository(FlightContext context) : GenericRepository<Vehicle>(context);

public interface IRepositoryManager
{
    IGenericRepository<Airline> Airline { get; }
    IGenericRepository<Airport> Airport { get; }
    IGenericRepository<Booking> Booking { get; }
    IGenericRepository<City> City { get; }
    IGenericRepository<Country> Country { get; }
    IGenericRepository<Domain.Entities.Flight> Flight { get; }
    IGenericRepository<Passenger> Passenger { get; }
    IGenericRepository<Vehicle> Vehicle { get; }
    void Save();
}