using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers;

/// <summary>
///     The parent controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ParentController(IServiceManager service, IRepositoryManager manager) : ControllerBase
{
    protected readonly IServiceManager Service = service;

    protected IRepositoryManager Manager = manager;
}