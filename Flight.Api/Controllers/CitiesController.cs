using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace Flight.Api.Controllers;

/// <summary>
///     The city controller.
/// </summary>
public class CitiesController : ParentController
{
    private readonly IGenericRepository<City> _cityRepository;

    public CitiesController(IRepositoryManager manager) : base(manager)
    {
        _cityRepository = Manager.City;
    }

    /// <summary>
    /// Gets all the cities.
    /// </summary>
    /// <returns>List of all real cities.</returns>
    [EndpointDescription("Display list of city.")]
    [ProducesResponseType(typeof(IEnumerable<City>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("cities")]
    [EndpointSummary("All cities")]
    public override async Task<IActionResult> GetAll()
    {
        var cities = await _cityRepository.AllAsync();
        return Ok(cities);
    }

    /// <summary>
    /// Retrieve a specific city's details by ID.
    /// </summary>
    /// <param name="id">The ID of the city to retrieve.</param>
    /// <returns>The details of the requested city.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetCityById")]
    [EndpointSummary("Get a city by id")]
    [EndpointDescription("Fetch a city by id or returns 404 if no city with the ID exists.")]
    [ProducesResponseType(typeof(City), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<City>> Get(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city == null) return NotFound();
        return Ok($"City found: {city}");
    }

    /// <summary>
    /// Create a new city.
    /// </summary>
    /// <param name="city">The city's information for creation.</param>
    /// <returns>A confirmation of the city's successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a city")]
    [EndpointDescription("Create a city or returns bad request.")]
    [ProducesResponseType(typeof(City), 200)]
    public async Task<ActionResult<City>> Create(CityDto city)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _cityRepository.AddAsync(new City(city));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok("City created successfully");
    }

    [HttpPut]
    [EndpointSummary("Update a city")]
    [EndpointDescription("Update city or returns bad request.")]
    public async Task<ActionResult<City>> Put([FromBody] CityDto city)
    {
        City item;
        try
        {
            item = await _cityRepository.GetByIdAsync(city.Id);
            item.Copy(city);
            await _cityRepository.Update(item);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"City updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete a city")]
    [EndpointDescription("delete city or returns bad request.")]
    public async Task<ActionResult<City>> Delete(int id)
    {
        var item = await _cityRepository.GetByIdAsync(id);
        if (item is null) return NotFound();
        try
        {
            await _cityRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"City deleted successfully: {item}");
    }
}