namespace NextMovie.Models.DTOs.Domain.Movies
{
    public class MovieCommentCreationDto
    {
        public required long TmdbMovieId { get; set; }

        public required string Comment { get; set; }
    }
}
