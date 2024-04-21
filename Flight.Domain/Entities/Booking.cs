using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

/// <summary>
///     The flight type.
/// </summary>
public enum Type
{
    Business,
    Economy
}

/// <summary>
///     The state.
/// </summary>
public enum Status
{
    Pending,
    Confirmed,
    Cancelled
}

public record BookingRecord(int Id, Type FlightType, int FlightId, Flight Plane, State state);

/// <summary>
///     The reservation.
/// </summary>
[Table("Bookings")]
public class Booking : DeleteEntity<int>
{
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
    public Status state { get; set; }
}