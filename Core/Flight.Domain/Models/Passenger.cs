using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The passenger.
    /// </summary>
    [Table("Passenger")]
    public class Passenger: BaseEntity
    {
        /// <summary>
        /// Gets or sets the airline id.
        /// </summary>
        [Column("PassengerId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public string? Contact { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string? Address{get;set;}
        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        public Genre Sex { get; set;}

}
}
