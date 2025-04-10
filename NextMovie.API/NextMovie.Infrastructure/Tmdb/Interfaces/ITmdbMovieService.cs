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
    }
}
