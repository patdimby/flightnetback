using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

/// <summary>
///     The flight.
/// </summary>
[Table("Flights")]
public class Flight : DeleteEntity<int>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Flight" /> class.
    /// </summary>
    public Flight()
    {
        Bookings = [];
    }

    /// <summary>
    ///     Gets or sets the code.
    /// </summary>
    [Required(ErrorMessage = "Flight code is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Code is 30 characters.")]
    [Column("code")]
    [JsonProperty(PropertyName = "code")]
    public string Code { get; set; } = "";

    /// <summary>
    ///     Gets or sets the departure.
    /// </summary>
    [Required(ErrorMessage = "Date of departure is a required field.")]
    [Column("departure")]
    [JsonProperty(PropertyName = "departure")]
    public DateTime Departure { get; set; }

    /// <summary>
    ///     Gets or sets the estimated arrival.
    /// </summary>
    [Required(ErrorMessage = "Date of arrival is a required field.")]
    [Column("arrival")]
    [JsonProperty(PropertyName = "arrival")]
    public DateTime EstimatedArrival { get; set; }

    /// <summary>
    ///     Gets or sets the business class slots.
    /// </summary>
    [Column("bus_slot")]
    [JsonProperty(PropertyName = "bus_slot")]
    public int BusinessClassSlots { get; set; }

    /// <summary>
    ///     Gets or sets the economy slots.
    /// </summary>
    [Column("eco_slot")]
    [JsonProperty(PropertyName = "eco_slot")]
    public int EconomySlots { get; set; }

    /// <summary>
    ///     Gets or sets the business class price.
    /// </summary>
    [Column("bus_price")]
    [JsonProperty(PropertyName = "bus_price")]
    public float BusinessClassPrice { get; set; }

    /// <summary>
    ///     Gets or sets the economy price.
    /// </summary>
    [Column("eco_price")]
    [JsonProperty(PropertyName = "eco_price")]
    public float EconomyPrice { get; set; }

    /// <summary>
    ///     Gets or sets the reservations.
    /// </summary>
    public virtual ICollection<Booking> Bookings { get; set; }

    /// <summary>
    ///     Identification of destination airport.
    /// </summary>
    [Column("flight_to")]
    [JsonProperty(PropertyName = "flight_to")]
    public int To { get; set; }

    /// <summary>
    ///     Gets or sets the destination airport.
    /// </summary>
    [ForeignKey(nameof(To))]
    public virtual Airport DestinationAirport { get; set; }

    /// <summary>
    ///     Identification of departure airport.
    /// </summary>
    [Column("flight_from")]
    [JsonProperty(PropertyName = "flight_from")]
    public int From { get; set; }

    /// <summary>
    ///     Gets or sets the departure airport.
    /// </summary>
    [ForeignKey(nameof(From))]
    public virtual Airport DepartureAirport { get; set; }
}