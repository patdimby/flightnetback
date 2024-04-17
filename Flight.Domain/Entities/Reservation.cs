using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

/// <summary>
///     The flight type.
/// </summary>
public enum Type
{
    BusinessClass,
    Economy
}

/// <summary>
///     The state.
/// </summary>
public enum State
{
    Pending,
    Confirmed,
    Cancelled
}

/// <summary>
///     The reservation.
/// </summary>
[Table("Reservations")]
public class Reservation : DeleteEntity<int>
{
    /// <summary>
    ///     Gets or sets the reservation.
    /// </summary>
    public Reservation reservation { get; set; } = new();

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
    public virtual Flight Plane { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    [Column("state")]
    [JsonProperty(PropertyName = "state")]
    public State state { get; set; }
}