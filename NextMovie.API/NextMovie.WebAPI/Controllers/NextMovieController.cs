using Microsoft.AspNetCore.Mvc;

namespace NextMovie.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    public class NextMovieController : ControllerBase
    {
    }
}
