using Microsoft.AspNetCore.Mvc;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    public class MoviesController : NextMovieController
    {
        private readonly ITmdbMovieService tmdbMovieService;
        private readonly IMovieService movieService;

        public MoviesController(ITmdbMovieService tmdbMovieService, IMovieService movieService)
        {
            this.tmdbMovieService = tmdbMovieService;
            this.movieService = movieService;
        }

        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> GetLatestAsync([FromQuery] int page = 1)
        {
            MoviePagedResponseDto movies = await tmdbMovieService.GetLatestAsync(page);
            return Ok(movies);
        }

        [HttpGet]
        [Route("details/{id:long}")]
        public async Task<IActionResult> GetDetailsAsync([FromRoute] long id)
        {
            MovieDetailsDto details = await movieService.GetMovieDetailsWithCommentsAsync(id);
            return Ok(details);
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> SearchAsync([FromBody] MovieSearchDto searchDto)
        {
            MoviePagedResponseDto movies = await tmdbMovieService.SearchAsync(searchDto);
            return Ok(movies);
        }
    }
}
