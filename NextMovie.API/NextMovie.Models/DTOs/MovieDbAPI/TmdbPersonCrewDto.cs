using System.Text.Json.Serialization;

namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbPersonCrewDto
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("known_for_department")]
        public required string KnownForDepartment { get; set; }

        [JsonPropertyName("character")]
        public string? Character { get; set; }
    }
}
