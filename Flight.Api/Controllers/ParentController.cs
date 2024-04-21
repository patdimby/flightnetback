using Flight.Application.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers;

/// <summary>
///     The parent controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ParentController : ControllerBase
{
    protected BaseApplication _application;
}