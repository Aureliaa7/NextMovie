using NextMovie.Application.Interfaces;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models.DTOs.MovieDbAPI;
using NextMovie.Models.Options;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class TmdbGenreService : ITmdbGenreService
    {
        private readonly IApiService apiService;
        private readonly TmdbSettings tmdbSettings;

        public TmdbGenreService(IApiService apiService, TmdbSettings tmdbSettings)
        {
            this.apiService = apiService;
            this.tmdbSettings = tmdbSettings;
        }

        public async Task<List<TmdbGenreDto>> GetAllAsync()
        {
            TmdbGenresDto apiResponse = (await apiService.GetAsync<TmdbGenresDto>(tmdbSettings.GenresEndpoint))!;

            return apiResponse.Genres;
        }
    }
}
