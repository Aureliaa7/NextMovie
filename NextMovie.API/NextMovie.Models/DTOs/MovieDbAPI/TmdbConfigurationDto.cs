using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbConfigurationDto
    {
        [JsonPropertyName("images")]
        public TmdbImagesConfigurationDto ImagesConfiguration { get; set; }
    }
}
