using Flight.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Flight.Api.Controllers;

public class FlightsController : ParentController
{
    private readonly IGenericRepository<Domain.Entities.Flight> _flightRepository;

    public FlightsController(IRepositoryManager manager) : base(manager)
    {
        _flightRepository = Manager.Flight;
    }

    /// <summary>
    /// Gets all the flights.
    /// </summary>
    /// <returns>List of all real flights.</returns>
    [EndpointDescription("Display list of flights.")]
    [ProducesResponseType(typeof(IEnumerable<Domain.Entities.Flight>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("flights")]
    [EndpointSummary("All flights")]
    public override async Task<IActionResult> GetAll()
    {
        var flights = await _flightRepository.AllAsync();

        return Ok(flights);
    }

    /// <summary>
    /// Retrieve a specific flight's details by ID.
    /// </summary>
    /// <param name="id">The ID of the flight to retrieve.</param>
    /// <returns>The details of the requested flight.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetFlightById")]
    [EndpointSummary("Get a flight by id")]
    [EndpointDescription("Fetch a flight by id or returns 404 if no flight with the ID exist.")]
    [ProducesResponseType(typeof(Domain.Entities.Flight), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<Domain.Entities.Flight>> Get(int id)
    {
        var flight = await _flightRepository.GetByIdAsync(id);
        if (flight == null) return NotFound();
        return Ok($"Flight found: {flight}");
    }

    /// <summary>
    /// Create a new flight.
    /// </summary>
    /// <param name="flight">The flight information for creation.</param>
    /// <returns>A confirmation of the flight successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a flight")]
    [EndpointDescription("Create a flight or returns bad request.")]
    [ProducesResponseType(typeof(Domain.Entities.Flight), 200)]
    public async Task<ActionResult<Domain.Entities.Flight>> Create(FlightDto flight)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _flightRepository.AddAsync(new Domain.Entities.Flight(flight));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok($"Flight created successfully: {flight}");
    }

    [HttpPut]
    [EndpointSummary("Update a flight")]
    [EndpointDescription("Update flight or returns bad request.")]
    public async Task<ActionResult<Domain.Entities.Flight>> Put([FromBody] FlightDto flight)
    {
        Domain.Entities.Flight item;
        try
        {
            item = await _flightRepository.GetByIdAsync(flight.Id);
            item.Copy(flight);
            await _flightRepository.Update(item);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Flight updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete a flight")]
    [EndpointDescription("delete flight or returns bad request.")]
    public async Task<ActionResult<Domain.Entities.Flight>> Delete(int id)
    {
        var item = await _flightRepository.GetByIdAsync(id);
        if (item is null) return NotFound();
        try
        {
            await _flightRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Flight deleted successfully: {item}");
    }
}