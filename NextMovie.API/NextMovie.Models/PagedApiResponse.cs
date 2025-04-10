using System.Text.Json.Serialization;

namespace NextMovie.Models
{
    /// <summary>
    /// Represents Movie DB API generic response.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedApiResponse<T>
    {
        [JsonPropertyName("results")]
        public List<T> Results { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
