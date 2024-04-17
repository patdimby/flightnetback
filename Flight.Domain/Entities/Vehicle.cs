using Flight.Domain.Core.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Entities
{
    public record VehicleRecord(int Id, string LicensePlate, string Manufacturer, string Model, short Year, float Tariff);

    /// <summary>
    /// The vehicle.
    /// </summary>
    [Table("Vehicles")]
    public class Vehicle : BaseEntity
    {
        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        [Column(name: "license")]
        [JsonProperty(PropertyName = "license")]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        [Column(name: "manufacturer")]
        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        [Column(name: "model")]
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        [Column(name: "year")]
        [JsonProperty(PropertyName = "year")]
        public short Year { get; set; }

        /// <summary>
        /// Gets or sets the tariff.
        /// </summary>
        [Column(name: "tariff")]
        [JsonProperty(PropertyName = "tariff")]
        public float Tariff { get; set; }
    }
}