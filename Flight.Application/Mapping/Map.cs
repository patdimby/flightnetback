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
        CreateMap<City, CityDto>();
        CreateMap<Country, CountryDto>();
        CreateMap<Vehicle, VehicleRecord>();
        CreateMap<Airline, AirlineDto>();
        CreateMap<Airport, AirportDto>();
        CreateMap<Domain.Entities.Flight, FlightDto>();
        CreateMap<Booking, BookingDto>();
        CreateMap<Passenger, PassengerRecord>();
    }
}