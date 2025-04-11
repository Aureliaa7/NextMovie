using NextMovie.Application.Interfaces;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class MovieService : IMovieService
    {
        private readonly ITmdbMovieService movieService;
        private readonly IMovieCommentService movieCommentService;

        public MovieService(ITmdbMovieService movieService, IMovieCommentService movieCommentService)
        {
            this.movieService = movieService;
            this.movieCommentService = movieCommentService;
        }

        public async Task<MovieDetailsDto> GetMovieDetailsWithCommentsAsync(long tmdbMovieId)
        {
            MovieDetailsDto movieDetails = await movieService.GetDetailsAsync(tmdbMovieId);
            List<MovieCommentDto> comments = await movieCommentService.GetAllAsync(tmdbMovieId);
            movieDetails.Comments = comments;

            return movieDetails;
        }
    }
}
