using Flight.Domain.Entities;
using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Flight.Api.Controllers;

/// <summary>
///     The city controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CityController(IServiceManager service, IRepositoryManager manager) : ParentController(service, manager)
{
   
    
    /// <summary>
    /// Gets all the cities.
    /// </summary>
    /// <returns>List of all real cities.</returns>
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var cities = await Manager.City.AllAsync();
        return Ok(cities);
    }

    /// <summary>
    /// Retrieve a specific city's details by ID.
    /// </summary>
    /// <param name="id">The ID of the city to retrieve.</param>
    /// <returns>The details of the requested city.</returns>
    [HttpGet("id")]  
    public async Task<ActionResult<City>> Get(int id)
    {
        var city = await Manager.City.GetByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return Ok(city);
    }

    /// <summary>
    /// Create a new city.
    /// </summary>
    /// <param name="city">The city's information for creation.</param>
    /// <returns>A confirmation of the city's successful creation.</returns>

    [HttpPost]
    public async Task<ActionResult<City>> Create(CityDto city)
    {
        if (!ModelState.IsValid)
        {           
            return BadRequest(ModelState);
        }
        try
        {
            await Manager.City.AddAsync(new City { Name = city.Name, Lat = city.Lat, Lon = city.Lon, CountryId = city.CountryId});
        }
        catch(Exception e)
        {
            return BadRequest(e.InnerException);
        }
        
        return Ok("City created successfully");
    }
}