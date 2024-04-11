namespace Flight.Domain.Models
{
    /// <summary>
    /// The vehicle input model.
    /// </summary>
    public class VehicleInputModel
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
        public short Year { get; set; }

        /// <summary>
        /// Gets or sets the tariff.
        /// </summary>
        public decimal Tariff { get; set; }
    }
}