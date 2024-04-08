using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The airport.
    /// </summary>
    [Table("Airport")]
    public class Airport: BaseEntity
    {
        /// <summary>
        /// Gets or sets the airline id.
        /// </summary>
        [Column("AirportId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirportId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Status Statut { get; set; } = Status.Active;
        /// <summary>
        /// Gets or sets the deleted flag.
        /// </summary>
        public int DeletedFlag { get; set; } = 0;
    }
}
