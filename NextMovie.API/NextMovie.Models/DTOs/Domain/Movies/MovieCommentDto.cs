namespace NextMovie.Models.DTOs.Domain.Movies
{
    public class MovieCommentDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public string CreatedAt { get; set; }

        public string AuthorFullName { get; set; }
    }
}
