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

public class AirportsController : ParentController
{
    private readonly IGenericRepository<Airport> _airlineRepository;

    public AirportsController(IRepositoryManager manager) : base(manager)
    {
        _airlineRepository = Manager.Airport;
    }

    /// <summary>
    /// Gets all the airports.
    /// </summary>
    /// <returns>List of all real airports.</returns>
    [EndpointDescription("Display list of airports.")]
    [ProducesResponseType(typeof(IEnumerable<Airport>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("airports")]
    [EndpointSummary("All airports")]
    public override async Task<IActionResult> GetAll()
    {
        var airports = await _airlineRepository.AllAsync();

        return Ok(airports);
    }

    /// <summary>
    /// Retrieve a specific airline's details by ID.
    /// </summary>
    /// <param name="id">The ID of the airline to retrieve.</param>
    /// <returns>The details of the requested airline.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetAirportById")]
    [EndpointSummary("Get a airline by id")]
    [EndpointDescription("Fetch a airline by id or returns 404 if no airline with the ID exist.")]
    [ProducesResponseType(typeof(Airport), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<Airport>> Get(int id)
    {
        var airline = await _airlineRepository.GetByIdAsync(id);
        if (airline == null) return NotFound();
        return Ok($"Airport found: {airline}");
    }

    /// <summary>
    /// Create a new airline.
    /// </summary>
    /// <param name="airline">The airline information for creation.</param>
    /// <returns>A confirmation of the airline successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a airline")]
    [EndpointDescription("Create a airline or returns bad request.")]
    [ProducesResponseType(typeof(Airport), 200)]
    public async Task<ActionResult<Airport>> Create(AirportDto airline)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _airlineRepository.AddAsync(new Airport(airline));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok($"Airport created successfully: {airline}");
    }

    [HttpPut]
    [EndpointSummary("Update a airline")]
    [EndpointDescription("Update airline or returns bad request.")]
    public async Task<ActionResult<Airport>> Put([FromBody] AirportDto airline)
    {
        Airport item;
        try
        {
            item = await _airlineRepository.GetByIdAsync(airline.Id);
            item.Copy(airline);
            await _airlineRepository.Update(item);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Airport updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete an airline")]
    [EndpointDescription("delete airline or returns bad request.")]
    public async Task<ActionResult<Airport>> Delete(int id)
    {
        var item = await _airlineRepository.GetByIdAsync(id);
        if (item is null) return NotFound();
        try
        {
            await _airlineRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Airport deleted successfully: {item}");
    }
}