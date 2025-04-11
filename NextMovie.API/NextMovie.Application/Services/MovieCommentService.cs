using NextMovie.Application.Entities;
using NextMovie.Application.Exceptions;
using NextMovie.Application.Interfaces;
using NextMovie.Models.DTOs.Domain.Movies;

namespace NextMovie.Application.Services
{
    public class MovieCommentService : IMovieCommentService
    {
        private readonly IRepository<MovieComment> movieCommentRepository;
        private readonly IRepository<User> userRepository;

        public MovieCommentService(
            IRepository<MovieComment> movieCommentRepository,
            IRepository<User> userRepository)
        {
            this.movieCommentRepository = movieCommentRepository;
            this.userRepository = userRepository;
        }

        public async Task<List<MovieCommentDto>> GetAllAsync(long tmdbMovieId)
        {
            var movies = (await movieCommentRepository.GetAllAsync(
                filter: c => c.TmdbMovieId == tmdbMovieId))
                .Select(c => new MovieCommentDto
                {
                    Id = c.Id,
                    AuthorFullName = $"{c.User.FirstName} {c.User.LastName}",
                    CreatedAt = c.CreatedAt.ToShortTimeString(),
                    Comment = c.Comment
                }).ToList();

            return movies;

        }

        public async Task<MovieCommentDto> SaveAsync(MovieCommentCreationDto comment, string currentUserId)
        {
            User currentUser = await userRepository.GetFirstOrDefaultAsync(u => u.Id.ToString() == currentUserId)
                ?? throw new EntityNotFoundException($"User with id {currentUserId} was not found!");

            var newComment = await movieCommentRepository.AddAsync(new MovieComment
            {
                Comment = comment.Comment,
                TmdbMovieId = comment.TmdbMovieId,
                UserId = new Guid(currentUserId),
                CreatedAt = DateTime.UtcNow
            });
            await movieCommentRepository.SaveAsync();
            return new MovieCommentDto
            {
                Id = newComment.Id,
                AuthorFullName = GetCommentAuthorFullName(currentUser),
                CreatedAt = newComment.CreatedAt.ToShortTimeString(),
                Comment = newComment.Comment
            };
        }

        private string GetCommentAuthorFullName(User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
