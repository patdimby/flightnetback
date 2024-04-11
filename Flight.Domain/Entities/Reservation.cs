using Flight.Domain.Core.Entities;
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
    [Table("Reservation")]
    public partial class Reservation : DeleteEntity<int>
    {
        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        public Reservation reservation { get; set; } = new();

        /// <summary>
        /// Gets or sets the flight type.
        /// </summary>
        public Type FlightType { get; set; } = Type.Economy;

        /// <summary>
        /// Gets or sets the flight id.
        /// </summary>
        public short FlightId { get; set; }

        /// <summary>
        /// Gets or sets the plane.
        /// </summary>
        [ForeignKey(nameof(FlightId))]
        public virtual Flight Plane { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public State state { get; set; }
    }
}