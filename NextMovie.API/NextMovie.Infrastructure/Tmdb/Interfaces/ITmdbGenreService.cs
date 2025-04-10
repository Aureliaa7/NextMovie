using NextMovie.Models.DTOs.MovieDbAPI;

namespace NextMovie.Infrastructure.Tmdb.Interfaces
{
    public interface ITmdbGenreService
    {
        /// <summary>
        /// Retrieves all movie genres 
        /// </summary>
        /// <returns>A list of movie genres</returns>
        Task<List<TmdbGenreDto>> GetAllAsync();
    }
}
