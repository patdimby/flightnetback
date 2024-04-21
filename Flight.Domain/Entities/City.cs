using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Entities;

public record CityRecord(int Id, string Name, decimal Lat, decimal Lon, int CountryId);

/// <summary>
///     The city.
/// </summary>
[Table("Cities")]
public class City : DeleteEntity<int>
{
    #region Properties

    /// <summary>
    ///     City name (in UTF8 format)
    /// </summary>
    [Required(ErrorMessage = "City name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    [Column("name")]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     City latitude
    /// </summary>

    [JsonProperty(PropertyName = "name")]
    [Column("lat", TypeName = "decimal(7,4)")]
    public decimal Lat { get; set; }

    /// <summary>
    ///     City longitude
    /// </summary>
    [Column("lon", TypeName = "decimal(7,4)")]
    public decimal Lon { get; set; }

    /// <summary>
    ///     Country Id (foreign key)
    /// </summary>
    [Column("country_id")]
    [JsonProperty(PropertyName = "country_id")]
    public int CountryId { get; set; }

    /// <summary>
    ///     Gets or sets the country.
    /// </summary>
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; }

    #endregion Properties
}