using Flight.Domain.Core.Models;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The vehicle model.
    /// </summary>
    public class VehicleModel : BaseModel
    {
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
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the tariff.
        /// </summary>
        public decimal Tariff { get; set; }
    }
}