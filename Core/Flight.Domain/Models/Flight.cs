using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The flight.
    /// </summary>
    [Table("Flight")]
    public class Flight: BaseEntity
    {
        /// <summary>
        /// Gets or sets the flight id.
        /// </summary>
        [Column("FlightId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// Gets or sets the departure.
        /// </summary>
        public DateTime Departure { get; set; }
        /// <summary>
        /// Gets or sets the estimated arrival.
        /// </summary>
        public DateTime EstimatedArrival { get; set; }
        /// <summary>
        /// Gets or sets the business class slots.
        /// </summary>
        public int BusinessClassSlots { get; set; }
        /// <summary>
        /// Gets or sets the economy slots.
        /// </summary>
        public int EconomySlots { get; set; }
        /// <summary>
        /// Gets or sets the business class price.
        /// </summary>
        public float BusinessClassPrice { get; set; }
        /// <summary>
        /// Gets or sets the economy price.
        /// </summary>
        public float EconomyPrice { get; set; }


    /// <summary>
    /// Gets or sets the reservations.
    /// </summary>
    public ICollection<Reservation>? Reservations { get; set; }
    }

}
