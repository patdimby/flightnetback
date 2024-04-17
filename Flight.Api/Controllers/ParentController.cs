using Flight.Domain.Core.Entities;
using Flight.Domain.Core.Interfaces;
using Flight.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api.Controllers
{
    /// <summary>
    /// The parent controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        protected IGenericApplication<DeleteEntity<int>> _baseApplication;
    }
}
