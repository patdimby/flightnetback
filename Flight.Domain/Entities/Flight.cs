using Flight.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The flight.
    /// </summary>
    [Table("Flight")]
    public partial class Flight : DeleteEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// </summary>
        public Flight()
        {
            Reservations = new HashSet<Reservation>();
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [Required(ErrorMessage = "Flight code is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Code is 30 characters.")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the departure.
        /// </summary>
        [Required(ErrorMessage = "Date of departure is a required field.")]
        public DateTime Departure { get; set; }

        /// <summary>
        /// Gets or sets the estimated arrival.
        /// </summary>
        [Required(ErrorMessage = "Date of arrival is a required field.")]
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
        public virtual ICollection<Reservation> Reservations { get; set; }

        /// <summary>
        /// Identification of destination airport.
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// Gets or sets the destination airport.
        /// </summary>
        [ForeignKey(nameof(To))]
        public virtual Airport DestinationAirport { get; set; }

        /// <summary>
        /// Identification of departure airport.
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Gets or sets the departure airport.
        /// </summary>
        [ForeignKey(nameof(From))]
        public virtual Airport DepartureAirport { get; set; }
    }
}