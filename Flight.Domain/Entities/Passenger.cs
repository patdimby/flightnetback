using Flight.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The genre.
    /// </summary>
    public enum Genre
    {
        Male, Female, Unknown
    }

    /// <summary>
    /// The passenger.
    /// </summary>
    [Table("Passenger")]
    public partial class Passenger : DeleteEntity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string MiddleName { get; set; } = "";

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; } = "";

        /// <summary>
        /// Gets or sets the email.
        /// </summary>

        [EmailAddress]
        public string Email { get; set; } = "";

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public string Contact { get; set; } = "";

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; } = "";

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        public Genre Sex { get; set; } = Genre.Unknown;
    }
}