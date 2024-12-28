using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

public record AirportDto(int Id, string Name, Status Statut, int DeletedFlag);

/// <summary>
///     The airport.
/// </summary>
[Table("Airports")]
public class Airport : DeleteEntity<int>
{
    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    [Column("name")]
    [JsonProperty(PropertyName = "name")]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the status.
    /// </summary>
    [Column("state")]
    [JsonProperty(PropertyName = "state")]
    public State Statut { get; set; } = State.Active;

    /// <summary>
    ///     Gets or sets the deleted flag.
    /// </summary>
    [Column("flag")]
    [JsonProperty(PropertyName = "flag")]
    public int DeletedFlag { get; set; }
}