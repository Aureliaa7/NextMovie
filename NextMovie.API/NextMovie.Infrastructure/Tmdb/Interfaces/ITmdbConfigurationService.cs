using NextMovie.Models.DTOs.MovieDbAPI;

namespace NextMovie.Infrastructure.Tmdb.Interfaces
{
    public interface ITmdbConfigurationService
    {
        /// <summary>
        /// Gets the configuration for the TMDB API
        /// </summary>
        /// <returns></returns>
        Task<TmdbConfigurationDto> GetAsync();
    }
}
