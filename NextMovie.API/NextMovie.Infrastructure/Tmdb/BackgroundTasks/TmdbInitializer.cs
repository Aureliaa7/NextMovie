using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Infrastructure.Tmdb.Services;
using NextMovie.Models.DTOs.MovieDbAPI;

namespace NextMovie.Infrastructure.Tmdb.BackgroundTasks
{
    /// <summary>
    /// Background service used to fetch and store TMDB genres in memory, 
    /// as well as images configuration (base url, available sizes)
    /// </summary>
    public class TmdbInitializer : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<TmdbInitializer> logger;

        public TmdbInitializer(IServiceProvider serviceProvider, ILogger<TmdbInitializer> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            TmdbStore tmdbStore = scope.ServiceProvider.GetRequiredService<TmdbStore>();
            await SetTmdbMovieGenresAsync(scope, tmdbStore);
            await SetConfigurationAsync(scope, tmdbStore);
        }

        private async Task SetTmdbMovieGenresAsync(IServiceScope scope, TmdbStore tmdbStore)
        {
            try
            {
                ITmdbGenreService genreService = scope.ServiceProvider.GetRequiredService<ITmdbGenreService>();
                List<TmdbGenreDto> genres = await genreService.GetAllAsync();
                tmdbStore.SetGenres(genres);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to fetch TMDB genres: {errorMessage}", ex.Message);
            }
        }

        private async Task SetConfigurationAsync(IServiceScope scope, TmdbStore tmdbStore)
        {
            try
            {
                ITmdbConfigurationService configurationService = scope.ServiceProvider.GetRequiredService<ITmdbConfigurationService>();
                TmdbConfigurationDto configuration = await configurationService.GetAsync();
                tmdbStore.SetConfiguration(configuration);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to fetch TMDB configuration: {errorMessage}", ex.Message);
            }
        }
    }
}
