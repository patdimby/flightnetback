using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

public record CountryDto(int Id, string Name, string Iso2, string Iso3);

/// <summary>
///     The country.
/// </summary>
[Table("Countries")]
public class Country : DeleteEntity<int>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Country" /> class.
    /// </summary>
    public Country()
    {
        Cities = [];
    }

    #region Properties

    /// <summary>
    ///     Country name (in UTF8 format)
    /// </summary>
    [Column("name")]
    [JsonProperty(PropertyName = "name")]
    [DataType(DataType.Text)]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Country code (in ISO 3166-1 ALPHA-2 format)
    /// </summary>
    [Column("iso2")]
    [JsonProperty(PropertyName = "iso2")]
    [DataType(DataType.Text)]
    public string ISO2 { get; set; } = null!;

    /// <summary>
    ///     Country code (in ISO 3166-1 ALPHA-3 format)
    /// </summary>
    [Column("iso3")]
    [JsonProperty(PropertyName = "iso3")]
    [DataType(DataType.Text)]
    public string ISO3 { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the cities.
    /// </summary>
    public virtual ICollection<City> Cities { get; set; }

    #endregion Properties
}