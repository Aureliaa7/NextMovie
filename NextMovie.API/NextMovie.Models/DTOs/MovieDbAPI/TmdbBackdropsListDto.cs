using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbBackdropsListDto
    {
        [JsonPropertyName("backdrops")]
        public List<TmdbBackdropDto> Backdrops { get; set; } = [];
    }
}
