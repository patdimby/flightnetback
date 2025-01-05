using System.Threading.Tasks;
using Flight.Domain.Core.Abstracts;
using Flight.Domain.Interfaces;
using Flight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers;

/// <summary>
///     The parent controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ParentController : ControllerBase
{
    protected IGenericRepository<DeleteEntity<int>> _repository { get; set; }
    protected IRepositoryManager Manager { get; }

    public ParentController(IRepositoryManager manager)
    {
        Manager = manager;
    }


    /// <summary>
    /// Gets all list of objects.
    /// </summary>
    /// <returns> To avoid rewrite the get verb in child controller. </returns>
    [HttpGet]
    public virtual Task<IActionResult> GetAll()
    {
        return Task.FromResult<IActionResult>(null);
    }
}