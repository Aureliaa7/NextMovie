using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbMovieCrewDto
    {
        [JsonPropertyName("cast")]
        public List<TmdbPersonCrewDto> Cast { get; set; } = new();
    }
}
