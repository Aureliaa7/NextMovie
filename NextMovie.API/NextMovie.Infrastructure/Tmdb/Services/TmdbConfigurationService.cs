using NextMovie.Application.Interfaces;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models.DTOs.MovieDbAPI;
using NextMovie.Models.Options;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class TmdbConfigurationService : ITmdbConfigurationService
    {
        private readonly IApiService apiService;
        private readonly TmdbSettings tmdbSettings;

        public TmdbConfigurationService(IApiService apiService, TmdbSettings tmdbSettings)
        {
            this.apiService = apiService;
            this.tmdbSettings = tmdbSettings;
        }

        public async Task<TmdbConfigurationDto> GetAsync()
        {
            TmdbConfigurationDto apiResponse = (await apiService.GetAsync<TmdbConfigurationDto>(tmdbSettings.ConfigurationEndpoint))!;

            return apiResponse;
        }
    }
}
