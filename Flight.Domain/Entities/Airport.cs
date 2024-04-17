using Flight.Domain.Core.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    public record AirportRecord(int Id, string Name, Status Statut, int DeletedFlag);

    /// <summary>
    /// The airport.
    /// </summary>
    [Table("Airports")]
    public partial class Airport : DeleteEntity<int>
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
        [Column("state")]
        [JsonProperty(PropertyName = "statut")]
        public Status Statut { get; set; } = Status.Active;

        /// <summary>
        /// Gets or sets the deleted flag.
        /// </summary>
        [Column("flag")]
        [JsonProperty(PropertyName = "flag")]
        public int DeletedFlag { get; set; } = 0;
    }
}