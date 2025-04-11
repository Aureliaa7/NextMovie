using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.Infrastructure.Tmdb.Interfaces
{
    public interface ITmdbCrewService
    {
        /// <summary>
        /// Gets the crew for a movie by its ID.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<List<PersonCrewDto>> GetByMovieIdAsync(long movieId);
    }
}
