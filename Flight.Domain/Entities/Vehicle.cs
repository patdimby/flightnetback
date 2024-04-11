using Flight.Domain.Core.Entities;

namespace Flight.Domain.Entities
{
    /// <summary>
    /// The vehicle.
    /// </summary>
    public class Vehicle : BaseEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public short Year { get; set; }

        /// <summary>
        /// Gets or sets the tariff.
        /// </summary>
        public decimal Tariff { get; set; }
    }
}