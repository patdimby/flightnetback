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

public class CountriesController : ParentController
{
    private readonly IGenericRepository<Country> _countryRepository;

    public CountriesController(IRepositoryManager manager) : base(manager)
    {
        _countryRepository = Manager.Country;
    }

    /// <summary>
    /// Gets all the countries.
    /// </summary>
    /// <returns>List of all real countries.</returns>
    [EndpointDescription("Display list of countries.")]
    [ProducesResponseType(typeof(IEnumerable<Country>), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    [EndpointName("countries")]
    [EndpointSummary("All countries")]
    public override async Task<IActionResult> GetAll()
    {
        var countries = await _countryRepository.AllAsync();

        return Ok(countries);
    }

    /// <summary>
    /// Retrieve a specific country's details by ID.
    /// </summary>
    /// <param name="id">The ID of the country to retrieve.</param>
    /// <returns>The details of the requested country.</returns>
    [HttpGet("{id:int}")]
    [EndpointName("GetCountryById")]
    [EndpointSummary("Get a country by id")]
    [EndpointDescription("Fetch a country by id or returns 404 if no country with the ID exist.")]
    [ProducesResponseType(typeof(Country), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
        "application/problem+json")]
    public async Task<ActionResult<Country>> Get(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        if (country == null) return NotFound();
        return Ok($"Country found: {country}");
    }

    /// <summary>
    /// Create a new country.
    /// </summary>
    /// <param name="country">The country information for creation.</param>
    /// <returns>A confirmation of the country successful creation.</returns>
    [HttpPost]
    [EndpointSummary("Create a country")]
    [EndpointDescription("Create a country or returns bad request.")]
    [ProducesResponseType(typeof(Country), 200)]
    public async Task<ActionResult<Country>> Create(CountryDto country)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _countryRepository.AddAsync(new Country(country));
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException);
        }

        return Ok($"Country created successfully: {country}");
    }

    [HttpPut]
    [EndpointSummary("Update a country")]
    [EndpointDescription("Update country or returns bad request.")]
    public async Task<ActionResult<Country>> Put([FromBody] CountryDto country)
    {
        Country item;
        try
        {
            item = await _countryRepository.GetByIdAsync(country.Id);
            item.Copy(country);
            await _countryRepository.Update(item);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Country updated successfully: {item}");
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Delete a country")]
    [EndpointDescription("delete country or returns bad request.")]
    public async Task<ActionResult<Country>> Delete(int id)
    {
        var item = await _countryRepository.GetByIdAsync(id);
        if (item is null) return NotFound();
        try
        {
            await _countryRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok($"Country deleted successfully: {item}");
    }
}