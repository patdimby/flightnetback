using Flight.Domain.Core.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The flight type.
    /// </summary>
    public enum Type
    {
        BusinessClass, Economy
    }

    /// <summary>
    /// The state.
    /// </summary>
    public enum State
    {
        Pending, Confirmed, Cancelled
    }

    /// <summary>
    /// The reservation.
    /// </summary>
    [Table("Reservations")]
    public partial class Reservation : DeleteEntity<int>
    {
        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        public Reservation reservation { get; set; } = new();

        /// <summary>
        /// Gets or sets the flight type.
        /// </summary>
        [Column(name: "flight_type")]
        [JsonProperty(PropertyName = "flight_type")]
        public Type FlightType { get; set; } = Type.Economy;

        /// <summary>
        /// Gets or sets the flight id.
        /// </summary>
        [Column(name: "flight_id")]
        [JsonProperty(PropertyName = "flight_id")]
        public int FlightId { get; set; }

        /// <summary>
        /// Gets or sets the plane.
        /// </summary>
        [ForeignKey(nameof(FlightId))]
        public virtual Flight Plane { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Column(name: "state")]
        [JsonProperty(PropertyName = "state")]
        public State state { get; set; }
    }
}