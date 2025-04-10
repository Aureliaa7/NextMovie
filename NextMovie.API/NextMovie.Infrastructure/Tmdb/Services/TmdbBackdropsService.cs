using NextMovie.Application.Interfaces;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models.DTOs.MovieDbAPI;
using NextMovie.Models.Options;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class TmdbBackdropsService : ITmdbBackdropsService
    {
        private readonly IApiService apiService;
        private readonly TmdbSettings tmdbSettings;
        private readonly TmdbStore tmdbStore;

        public TmdbBackdropsService(IApiService apiService, TmdbSettings tmdbSettings, TmdbStore tmdbStore)
        {
            this.apiService = apiService;
            this.tmdbSettings = tmdbSettings;
            this.tmdbStore = tmdbStore;
        }

        public async Task<List<string>> GetByMovieIdAsync(string movieId)
        {
            TmdbBackdropsListDto response = (await apiService.GetAsync<TmdbBackdropsListDto>(string.Format(tmdbSettings.MovieImagesEndpoint, movieId)))!;

            List<string> backdrops = response.Backdrops
                .Select(x => tmdbStore.GetImageUrl(x.FilePath, tmdbSettings.DefaultBackdropSize))
                .ToList();

            return backdrops;
        }
    }
}
