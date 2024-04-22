using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    /// Gets the cities.
    /// </summary>
    /// <returns>A Task.</returns>
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var companies = await _manager.City.AllAsync();

        return Ok(companies);
    }
}