using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.Infrastructure.Tmdb.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Gets movie details and comments
        /// </summary>
        /// <param name="tmdbMovieId"></param>
        /// <returns></returns>
        Task<MovieDetailsDto> GetMovieDetailsWithCommentsAsync(long tmdbMovieId);
    }
}
