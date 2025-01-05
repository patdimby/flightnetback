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

public class AirlinesController : ParentController
{
    private readonly IGenericRepository<Airline> _airlineRepository;

    public AirlinesController(IRepositoryManager manager) : base(manager)
    {
        _airlineRepository = Manager.Airline;
    }

    /// <summary>
    /// Gets all the airlines.
    /// </summary>
    /// <returns>List of all real airlines.</returns>
    [EndpointDescription("Display list of airlines.")]
    [ProducesResponseType(typeof(IEnumerable<Airline>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("airlines")]
    [EndpointSummary("All airlines")]
    public override async Task<IActionResult> GetAll()
    {
        var airlines = await _airlineRepository.AllAsync();

        return Ok(airlines);
    }

    /// <summary>
    /// Retrieve a specific airline's details by ID.
    /// </summary>
    /// <param name="id">The ID of the airline to retrieve.</param>
    /// <returns>The details of the requested airline.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetAirlineById")]
    [EndpointSummary("Get a airline by id")]
    [EndpointDescription("Fetch a airline by id or returns 404 if no airline with the ID exist.")]
    [ProducesResponseType(typeof(Airline), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<Airline>> Get(int id)
    {
        var airline = await _airlineRepository.GetByIdAsync(id);
        if (airline == null) return NotFound();
        return Ok($"Airline found: {airline}");
    }

    /// <summary>
    /// Create a new airline.
    /// </summary>
    /// <param name="airline">The airline information for creation.</param>
    /// <returns>A confirmation of the airline successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a airline")]
    [EndpointDescription("Create a airline or returns bad request.")]
    [ProducesResponseType(typeof(Airline), 200)]
    public async Task<ActionResult<Airline>> Create(AirlineDto airline)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _airlineRepository.AddAsync(new Airline(airline));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok($"Airline created successfully: {airline}");
    }

    [HttpPut]
    [EndpointSummary("Update a airline")]
    [EndpointDescription("Update airline or returns bad request.")]
    public async Task<ActionResult<Airline>> Put([FromBody] AirlineDto airline)
    {
        Airline item;
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

        return Ok($"Airline updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete a airline")]
    [EndpointDescription("delete airline or returns bad request.")]
    public async Task<ActionResult<Airline>> Delete(int id)
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

        return Ok($"Airline deleted successfully: {item}");
    }
}