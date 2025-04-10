using Microsoft.AspNetCore.Mvc;

namespace NextMovie.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NextMovieController : ControllerBase
    {
    }
}
