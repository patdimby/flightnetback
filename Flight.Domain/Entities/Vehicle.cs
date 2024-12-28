using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

public record VehicleRecord(int Id, string LicensePlate, string Manufacturer, string Model, short Year, float Tariff);

/// <summary>
///     The vehicle.
/// </summary>
[Table("Vehicles")]
public class Vehicle : DeleteEntity<int>
{
    /// <summary>
    ///     Gets or sets the license plate.
    /// </summary>
    [Column("license")]
    [JsonProperty(PropertyName = "license")]
    [DataType(DataType.Text)]
    public string LicensePlate { get; set; }

    /// <summary>
    ///     Gets or sets the manufacturer.
    /// </summary>
    [Column("manufacturer")]
    [JsonProperty(PropertyName = "manufacturer")]
    [DataType(DataType.Text)]
    public string Manufacturer { get; set; }

    /// <summary>
    ///     Gets or sets the model.
    /// </summary>
    [Column("model")]
    [JsonProperty(PropertyName = "model")]
    [DataType(DataType.Text)]
    public string Model { get; set; }

    /// <summary>
    ///     Gets or sets the year.
    /// </summary>
    [Column("year")]
    [JsonProperty(PropertyName = "year")]
    public short Year { get; set; }

    /// <summary>
    ///     Gets or sets the tariff.
    /// </summary>
    [Column("tariff")]
    [JsonProperty(PropertyName = "tariff")]
    public float Tariff { get; set; }
}