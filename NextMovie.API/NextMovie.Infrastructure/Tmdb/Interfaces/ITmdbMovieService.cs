using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.Infrastructure.Tmdb.Interfaces
{
    public interface ITmdbMovieService
    {
        /// <summary>
        /// Gets TMDB latest movies
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<MoviePagedResponseDto> GetLatestAsync(int pageNumber = 1);

        /// <summary>
        /// Gets movie details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MovieDetailsDto> GetDetailsAsync(long id);

        /// <summary>
        /// Searches for movies by title. If no results are found, it will search by genre
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<MoviePagedResponseDto> SearchAsync(MovieSearchDto query);
    }
}
