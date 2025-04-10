namespace NextMovie.Models.Options
{
    public class TmdbSettings
    {
        public const string Tmdb = "TmdbApi";

        public string BaseUrl { get; set; } = string.Empty;

        public string ApiKey { get; set; } = string.Empty;

        public string GenresEndpoint { get; set; } = string.Empty;

        public string LatestMoviesEndpoint { get; set; } = string.Empty;

        public string ConfigurationEndpoint { get; set; } = string.Empty;

        public string DefaultBackdropSize { get; set; } = string.Empty;

        public string MovieImagesEndpoint { get; set; } = string.Empty;

        public string MovieCreditsEndpoint { get; set; } = string.Empty;
    }
}
