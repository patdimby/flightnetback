using Flight.Domain.Entities;
using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Flight.Api.Controllers;

/// <summary>
///     The country controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CountryController(IServiceManager service, IRepositoryManager manager) : ParentController(service, manager)
{
    /// <summary>
    /// Gets all the countries.
    /// </summary>
    /// <returns>List of all real countries.</returns>
    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await Manager.Country.AllAsync();
        return Ok(countries);
    }

    /// <summary>
    /// Retrieve a specific country's details by ID.
    /// </summary>
    /// <param name="id">The ID of the country to retrieve.</param>
    /// <returns>The details of the requested country.</returns>
    [HttpGet("id")]
    public async Task<ActionResult<Country>> Get(int id)
    {
        var country = await Manager.Country.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        return Ok(country);
    }

    /// <summary>
    /// Create a new country.
    /// </summary>
    /// <param name="country">The country information for creation.</param>
    /// <returns>A confirmation of the country successful creation.</returns>
    [HttpPost]
    public async Task<ActionResult<Country>> Create(CountryDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await Manager.Country.AddAsync(new Country { Name = country.Name });
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok("Country created successfully");
    }
}