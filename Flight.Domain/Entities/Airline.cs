using Flight.Domain.Core.Entities;
using Newtonsoft.Json;
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

    public record AirlineRecord(int Id, string Name, Status Statut, int DeletedFlag);

    /// <summary>
    /// The airline.
    /// </summary>
    [Table("Airlines")]
    public partial class Airline : DeleteEntity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        [Column("name")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [Required(ErrorMessage = "State must be given.")]
        [Column("state")]
        [JsonProperty(PropertyName = "name")]
        public Status Statut { get; set; } = Status.Active;

        /// <summary>
        /// Gets or sets the deleted flag.
        /// </summary>
        [Column("flag")]
        [JsonProperty(PropertyName = "flag")]
        public int DeletedFlag { get; set; } = 0;
    }
}