using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbBackdropDto
    {
        [JsonPropertyName("file_path")]
        public string FilePath { get; set; } = string.Empty;
    }
}
