using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbGenresDto
    {
        [JsonPropertyName("genres")]
        public List<TmdbGenreDto> Genres { get; set; } = [];
    }
}
