using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The reservation.
    /// </summary>
    [Table("Reservation")]
    public class Reservation: BaseEntity
    {
        /// <summary>
        /// Gets or sets the reservationid.
        /// </summary>
        [Column("ReservationId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        /// <summary>
        /// Gets or sets the flight ref id.
        /// </summary>
        public int FlightRefId { get; set; }

        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        [ForeignKey("FlightRefId")]
        public Reservation? ActualReservation { get; set; }
        /// <summary>
        /// Gets or sets the flight type.
        /// </summary>
        public Type FlightType { get; set; }= Type.Economy;
    }
}
