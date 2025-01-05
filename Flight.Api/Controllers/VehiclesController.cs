using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Flight.Api.Controllers;

public class VehiclesController : ParentController
{
    private readonly IGenericRepository<Vehicle> _vehicleRepository;

    public VehiclesController(IRepositoryManager manager) : base(manager)
    {
        _vehicleRepository = Manager.Vehicle;
    }

    /// <summary>
    /// Gets all the vehicles.
    /// </summary>
    /// <returns>List of all real vehicles.</returns>
    [EndpointDescription("Display list of vehicles.")]
    [ProducesResponseType(typeof(IEnumerable<Vehicle>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("vehicles")]
    [EndpointSummary("All vehicles")]
    public override async Task<IActionResult> GetAll()
    {
        var vehicles = await _vehicleRepository.AllAsync();

        return Ok(vehicles);
    }

    /// <summary>
    /// Retrieve a specific vehicle's details by ID.
    /// </summary>
    /// <param name="id">The ID of the vehicle to retrieve.</param>
    /// <returns>The details of the requested vehicle.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetVehicleById")]
    [EndpointSummary("Get a vehicle by id")]
    [EndpointDescription("Fetch a vehicle by id or returns 404 if no vehicle with the ID exist.")]
    [ProducesResponseType(typeof(Vehicle), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<Vehicle>> Get(int id)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);
        if (vehicle == null) return NotFound();
        return Ok($"Vehicle found: {vehicle}");
    }

    /// <summary>
    /// Create a new vehicle.
    /// </summary>
    /// <param name="vehicle">The vehicle information for creation.</param>
    /// <returns>A confirmation of the vehicle successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a vehicle")]
    [EndpointDescription("Create a vehicle or returns bad request.")]
    [ProducesResponseType(typeof(Vehicle), 200)]
    public async Task<ActionResult<Vehicle>> Create(VehicleDto vehicle)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _vehicleRepository.AddAsync(new Vehicle(vehicle));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok($"Vehicle created successfully: {vehicle}");
    }

    [HttpPut]
    [EndpointSummary("Update a vehicle")]
    [EndpointDescription("Update vehicle or returns bad request.")]
    public async Task<ActionResult<Vehicle>> Put([FromBody] VehicleDto vehicle)
    {
        Vehicle item;
        try
        {
            item = await _vehicleRepository.GetByIdAsync(vehicle.Id);
            item.Copy(vehicle);
            await _vehicleRepository.Update(item);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Vehicle updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete a vehicle")]
    [EndpointDescription("delete vehicle or returns bad request.")]
    public async Task<ActionResult<Vehicle>> Delete(int id)
    {
        var item = await _vehicleRepository.GetByIdAsync(id);
        if(item is null) return NotFound();
        try
        {
            await _vehicleRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Vehicle deleted successfully: {item}");
    }
}