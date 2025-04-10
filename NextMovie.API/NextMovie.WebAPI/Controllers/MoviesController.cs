using Microsoft.AspNetCore.Mvc;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    public class MoviesController : NextMovieController
    {
        private readonly ITmdbMovieService movieService;

        public MoviesController(ITmdbMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> GetLatestAsync([FromQuery] int page = 1)
        {
            MoviePagedResponseDto movies = await movieService.GetLatestAsync(page);
            return Ok(movies);
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> GetDetailsAsync([FromRoute] string id)
        {
            MovieDetailsDto details = await movieService.GetDetailsAsync(id);
            return Ok(details);
        }
    }
}
