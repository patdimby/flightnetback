using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

public static class BookingExtensions
{
    public static BookingDto ToDto(this Booking booking)
    {
        return new BookingDto(booking.Id, booking.FlightType, booking.FlightId,
            booking.Plane, booking.Statut);
    }
}

public record BookingDto(int Id, Type FlightType, int FlightId, Flight Plane, Statut Statut);

/// <summary>
///     The reservation.
/// </summary>
[Table("Bookings")]
public class Booking : DeleteEntity<int>
{
    public Booking()
    {
    }

    public Booking(BookingDto dto)
    {
        Copy(dto);
    }

    /// <summary>
    ///     Gets or sets the flight type.
    /// </summary>
    [Column("flight_type")]
    [JsonProperty(PropertyName = "flight_type")]
    public Type FlightType { get; set; } = Type.Economy;

    /// <summary>
    ///     Gets or sets the flight id.
    /// </summary>
    [Column("flight_id")]
    [JsonProperty(PropertyName = "flight_id")]
    public int FlightId { get; set; }

    /// <summary>
    ///     Gets or sets the plane.
    /// </summary>
    [ForeignKey(nameof(FlightId))]
    public Flight Plane { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    [Column("state")]
    [JsonProperty(PropertyName = "state")]
    public Statut Statut { get; set; }

    public void Copy(BookingDto dto)
    {
        Id = dto.Id > 0 ? dto.Id : 0;
        FlightType = dto.FlightType;
        FlightId = dto.FlightId;
        Plane = dto.Plane;
        Statut = dto.Statut;
    }
}