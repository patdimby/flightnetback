using AutoMapper;
using Flight.Domain.Entities;

namespace Flight.Application.Mapping;

/// <summary>
///     The vehicle map.
/// </summary>
public class Map : Profile
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Map" /> class.
    /// </summary>
    public Map()
    {
        CreateMap<City, CityRecord>();
        CreateMap<Country, CountryRecord>();
        CreateMap<Vehicle, VehicleRecord>();
        CreateMap<Airline, AirlineRecord>();
        CreateMap<Airport, AirportRecord>();
        CreateMap<Domain.Entities.Flight, FlightRecord>();
        CreateMap<Booking, BookingRecord>();
        CreateMap<Passenger, PassengerRecord>();
    }
}