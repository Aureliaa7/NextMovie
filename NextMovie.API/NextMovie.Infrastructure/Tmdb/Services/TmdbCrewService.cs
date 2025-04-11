using NextMovie.Application.Interfaces;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models.DTOs.Domain.Movies;
using NextMovie.Models.DTOs.MovieDbAPI;
using NextMovie.Models.Options;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class TmdbCrewService : ITmdbCrewService
    {
        private readonly IApiService apiService;
        private readonly TmdbSettings tmdbSettings;

        public TmdbCrewService(IApiService apiService, TmdbSettings tmdbSettings)
        {
            this.apiService = apiService;
            this.tmdbSettings = tmdbSettings;
        }

        public async Task<List<PersonCrewDto>> GetByMovieIdAsync(long movieId)
        {
            TmdbMovieCrewDto response = (await apiService.GetAsync<TmdbMovieCrewDto>(string.Format(tmdbSettings.MovieCreditsEndpoint, movieId)))!;
            var cast = response.Cast
                .Select(x => new PersonCrewDto
                {
                    Department = x.KnownForDepartment,
                    Name = x.Name,
                    Character = x.Character
                })
                .ToList();

            return cast;
        }
    }
}
