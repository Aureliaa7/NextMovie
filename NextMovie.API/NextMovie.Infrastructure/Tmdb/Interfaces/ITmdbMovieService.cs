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
        Task<MovieDetailsDto> GetDetailsAsync(string id);
    }
}
