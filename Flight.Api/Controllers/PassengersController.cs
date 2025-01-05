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

public class PassengersController : ParentController
{
    private readonly IGenericRepository<Passenger> _passengerRepository;

    public PassengersController(IRepositoryManager manager) : base(manager)
    {
        _passengerRepository = Manager.Passenger;
    }

    /// <summary>
    /// Gets all the passengers.
    /// </summary>
    /// <returns>List of all real passengers.</returns>
    [EndpointDescription("Display list of passengers.")]
    [ProducesResponseType(typeof(IEnumerable<Passenger>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("passengers")]
    [EndpointSummary("All passengers")]
    public override async Task<IActionResult> GetAll()
    {
        var passengers = await _passengerRepository.AllAsync();

        return Ok(passengers);
    }

    /// <summary>
    /// Retrieve a specific passenger's details by ID.
    /// </summary>
    /// <param name="id">The ID of the passenger to retrieve.</param>
    /// <returns>The details of the requested passenger.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetPassengerById")]
    [EndpointSummary("Get a passenger by id")]
    [EndpointDescription("Fetch a passenger by id or returns 404 if no passenger with the ID exist.")]
    [ProducesResponseType(typeof(Passenger), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<Passenger>> Get(int id)
    {
        var passenger = await _passengerRepository.GetByIdAsync(id);
        if (passenger == null) return NotFound();
        return Ok($"Passenger found: {passenger}");
    }

    /// <summary>
    /// Create a new passenger.
    /// </summary>
    /// <param name="passenger">The passenger information for creation.</param>
    /// <returns>A confirmation of the passenger successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a passenger")]
    [EndpointDescription("Create a passenger or returns bad request.")]
    [ProducesResponseType(typeof(Passenger), 200)]
    public async Task<ActionResult<Passenger>> Create(PassengerDto passenger)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _passengerRepository.AddAsync(new Passenger(passenger));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok($"Passenger created successfully: {passenger}");
    }

    [HttpPut]
    [EndpointSummary("Update a passenger")]
    [EndpointDescription("Update passenger or returns bad request.")]
    public async Task<ActionResult<Passenger>> Put([FromBody] PassengerDto passenger)
    {
        Passenger item;
        try
        {
            item = await _passengerRepository.GetByIdAsync(passenger.Id);
            item.Copy(passenger);
            await _passengerRepository.Update(item);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Passenger updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete a passenger")]
    [EndpointDescription("delete passenger or returns bad request.")]
    public async Task<ActionResult<Passenger>> Delete(int id)
    {
        var item = await _passengerRepository.GetByIdAsync(id);
        if (item is null) return NotFound();
        try
        {
            await _passengerRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Passenger deleted successfully: {item}");
    }
}