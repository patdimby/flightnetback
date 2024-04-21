using AutoMapper;
using Flight.Application.Applications;
using Flight.Domain.Entities;
using Flight.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers;

/// <summary>
///     The city controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CityController(IMapper mapper, IGenericRepository<City> repository) : ControllerBase
{
    public BaseApplication _baseApplication = new(mapper, repository);
}