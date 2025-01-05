using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flight.Domain.Core.Abstracts;
using Newtonsoft.Json;

namespace Flight.Domain.Entities;

public static class VehicleExtensions
{
    public static VehicleDto ToDto(this Vehicle vehicle)
    {
        return new VehicleDto(vehicle.Id, vehicle.LicensePlate, vehicle.Manufacturer, vehicle.Model, vehicle.Year,
            vehicle.Tariff);
    }
}

public record VehicleDto(int Id, string LicensePlate, string Manufacturer, string Model, short Year, float Tariff);

/// <summary>
///     The vehicle.
/// </summary>
[Table("Vehicles")]
public class Vehicle : DeleteEntity<int>
{
    public Vehicle()
    {
    }

    public Vehicle(VehicleDto dto)
    {
        Copy(dto);
    }

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

    public void Copy(VehicleDto dto)
    {
        Id = dto.Id > 0 ? dto.Id : 0;
        LicensePlate = dto.LicensePlate;
        Manufacturer = dto.Manufacturer;
        Model = dto.Model;
        Year = dto.Year;
        Tariff = dto.Tariff;
    }
}