namespace NextMovie.Infrastructure.Tmdb.Interfaces
{
    public interface ITmdbBackdropsService
    {
        /// <summary>
        /// Returns a list of backdrops for a movie by its ID.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>A list of images paths</returns>
        Task<List<string>> GetByMovieIdAsync(long movieId);
    }
}
