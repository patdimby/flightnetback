using Flight.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The status.
    /// </summary>
    public enum Status
    {
        Active, Inactive
    }

    /// <summary>
    /// The airline.
    /// </summary>
    [Table("Airline")]
    public partial class Airline : DeleteEntity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

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