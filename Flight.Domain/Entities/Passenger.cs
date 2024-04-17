using Flight.Domain.Core.Entities;
using Newtonsoft.Json;
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
    [Table("Passengers")]
    public partial class Passenger : DeleteEntity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        [Column(name: "name")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        [MaxLength(100, ErrorMessage = "Maximum length for middle name is 100 characters.")]
        [Column(name: "middle_name")]
        [JsonProperty(PropertyName = "middle_name")]
        public string MiddleName { get; set; } = "";

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [MaxLength(100, ErrorMessage = "Maximum length for last name is 100 characters.")]
        [Column(name: "last_name")]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; } = "";

        /// <summary>
        /// Gets or sets the email.
        /// </summary>

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [Column(name: "email")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = "";

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        [Required(ErrorMessage = "Contact is required.")]
        [Column(name: "contact")]
        [JsonProperty(PropertyName = "contact")]
        public string Contact { get; set; } = "";

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [Required(ErrorMessage = "Address is required.")]
        [Column(name: "address")]
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; } = "";

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        [Required(ErrorMessage = "Genre is required.")]
        [Column(name: "genre")]
        [JsonProperty(PropertyName = "genre")]
        public Genre Sex { get; set; } = Genre.Unknown;
    }
}