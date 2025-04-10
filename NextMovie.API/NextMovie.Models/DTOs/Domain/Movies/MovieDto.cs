namespace NextMovie.Models.DTOs.Domain.Movies
{
    public class MovieDto
    {
        public required string BackdropPath { get; init; }

        public required long Id { get; init; }

        public required string Title { get; init; }

        public required string Overview { get; init; }

        public required string ReleaseDate { get; init; }

        public required string OriginalLanguage { get; init; }

        public float VoteAverage { get; init; }

        public long VoteCount { get; init; }

        public List<string> Genres { get; init; } = [];
    }
}
