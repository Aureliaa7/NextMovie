using NextMovie.Models.DTOs.MovieDbAPI;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class TmdbStore
    {
        private readonly List<TmdbGenreDto> genres = new();
        private string imagesUrl = string.Empty;
        private readonly List<string> backdropSizes = new();

        public void SetGenres(IEnumerable<TmdbGenreDto> genres)
        {
            this.genres.Clear();
            this.genres.AddRange(genres);
        }

        public void SetConfiguration(TmdbConfigurationDto configuration)
        {
            imagesUrl = configuration.ImagesConfiguration.SecureBaseUrl;
            backdropSizes.Clear();
            backdropSizes.AddRange(configuration.ImagesConfiguration.BackdropSizes);
        }

        public IReadOnlyList<TmdbGenreDto> GetAllGenres() => genres;

        public IReadOnlyList<string> GetBackdropSizes() => backdropSizes;

        public string GetImageUrl(string imagePath, string imageSize)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return string.Empty;
            }

            string size = string.IsNullOrWhiteSpace(imageSize) ? backdropSizes.First() : imageSize;

            return $"{imagesUrl}{size}{imagePath}";
        }
    }
}
