using Flight.Domain.Core.Interfaces;
using Flight.Domain.Entities;
using Flight.Util;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Flight.Api.Controllers
{
    /// <summary>
    /// The vehicle controller.
    /// </summary>
    [ApiController]
    [Route(Constants.Routs.Vehicle)]
    public class VehicleController : ControllerBase
    {
        private readonly IGenericApplication<Vehicle> _vehicleApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleController"/> class.
        /// </summary>
        /// <param name="weatherForecastApplication">The weather forecast application.</param>
        public VehicleController(IGenericApplication<Vehicle> weatherForecastApplication)
        {
            _vehicleApplication = weatherForecastApplication;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns>A Task.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _vehicleApplication.GetAsync();

            if (result == null)
                return NotFound(Constants.ReturnMessages.NotFound);

            return Ok(result.Object);
        }

        /// <summary>
        /// Gets the by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _vehicleApplication.GetByIdAsync(id);

            if (result == null)
                return NotFound(Constants.ReturnMessages.NotFound);

            return Ok(result.Object);
        }

        /// <summary>
        /// Posts the.
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        /// <returns>A Task.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vehicle vehicle)
        {
            var result = await _vehicleApplication.PostAsync(vehicle);

            if (!result.Success)
                return BadRequest(result.Notifications);

            return Ok(result);
        }

        /// <summary>
        /// Puts the.
        /// </summary>
        /// <param name="veichle">The veichle.</param>
        /// <returns>A Task.</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Vehicle veichle)
        {
            var result = await _vehicleApplication.PutAsync(veichle);

            if (!result.Success)
                return BadRequest(result.Notifications);

            return Ok(result);
        }

        /// <summary>
        /// Deletes the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vehicleApplication.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Notifications);

            return Ok(result);
        }
    }
}