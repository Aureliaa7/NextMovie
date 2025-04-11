using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.Application.Interfaces
{
    public interface IMovieCommentService
    {
        /// <summary>
        /// Saves a movie comment
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        Task<MovieCommentDto> SaveAsync(MovieCommentCreationDto comment, string currentUserId);

        /// <summary>
        /// Gets all comments for a movie based on its TMDB id
        /// </summary>
        /// <param name="tmdbMovieId"></param>
        /// <returns></returns>
        Task<List<MovieCommentDto>> GetAllAsync(long tmdbMovieId);
    }
}
