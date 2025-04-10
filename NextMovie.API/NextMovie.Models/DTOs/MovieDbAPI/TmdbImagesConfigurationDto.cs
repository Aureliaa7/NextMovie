using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbImagesConfigurationDto
    {
        [JsonPropertyName("secure_base_url")]
        public required string SecureBaseUrl { get; set; }

        [JsonPropertyName("backdrop_sizes")]
        public List<string> BackdropSizes { get; set; } = [];
    }
}
