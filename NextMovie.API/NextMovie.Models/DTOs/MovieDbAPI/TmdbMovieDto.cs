using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbMovieDto
    {
        [JsonPropertyName("backdrop_path")]
        public required string BackdropPath { get; init; }

        [JsonPropertyName("id")]
        public required long Id { get; init; }

        [JsonPropertyName("title")]
        public required string Title { get; init; }

        [JsonPropertyName("overview")]
        public required string Overview { get; init; }

        [JsonPropertyName("release_date")]
        public required string ReleaseDate { get; init; }

        [JsonPropertyName("original_language")]
        public required string OriginalLanguage { get; init; }

        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; init; }

        [JsonPropertyName("vote_count")]
        public long VoteCount { get; init; }

        [JsonPropertyName("genre_ids")]
        public List<int> Genre_Ids { get; init; } = [];
    }
}
