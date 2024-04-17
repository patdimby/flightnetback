using Flight.Application.Interfaces;
using Flight.Domain.Core.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers;

/// <summary>
///     The parent controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ParentController : ControllerBase
{
    protected IGenericApplication<DeleteEntity<int>> _baseApplication;
}