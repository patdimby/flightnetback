using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

/// <summary>
///     The status.
/// </summary>
public enum State
{
    Active,
    Inactive
}

public record AirlineRecord(int Id, string Name, Status Statut, int DeletedFlag);

/// <summary>
///     The airline.
/// </summary>
[Table("Airlines")]
public class Airline : DeleteEntity<int>
{
    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    [Required(ErrorMessage = "Airline name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    [Column("name")]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the status.
    /// </summary>
    [Required(ErrorMessage = "State must be given.")]
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