using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbConfigurationDto
    {
        [JsonPropertyName("images")]
        public required TmdbImagesConfigurationDto ImagesConfiguration { get; set; }
    }
}
