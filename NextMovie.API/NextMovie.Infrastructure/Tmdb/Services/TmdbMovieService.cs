using NextMovie.Application.Interfaces;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Models;
using NextMovie.Models.DTOs.Domain.Movies;
using NextMovie.Models.DTOs.MovieDbAPI;
using NextMovie.Models.Options;

namespace NextMovie.Infrastructure.Tmdb.Services
{
    public class TmdbMovieService : ITmdbMovieService
    {
        private readonly IApiService apiService;
        private readonly TmdbSettings tmdbSettings;
        private readonly TmdbStore genresStore;
        private readonly ITmdbBackdropsService backdropsService;
        private readonly ITmdbCrewService crewService;

        public TmdbMovieService(IApiService apiService,
            TmdbSettings tmdbSettings,
            TmdbStore genresStore,
            ITmdbBackdropsService backdropsService,
            ITmdbCrewService crewService)
        {
            this.apiService = apiService;
            this.tmdbSettings = tmdbSettings;
            this.genresStore = genresStore;
            this.backdropsService = backdropsService;
            this.crewService = crewService;
        }

        public async Task<MovieDetailsDto> GetDetailsAsync(string id)
        {
            List<string> backdrops = await backdropsService.GetByMovieIdAsync(id);
            List<PersonCrewDto> crew = await crewService.GetByMovieIdAsync(id);

            return new MovieDetailsDto
            {
                BackdropPaths = backdrops,
                Crew = crew,
                Id = id
            };
        }

        public async Task<MoviePagedResponseDto> GetLatestAsync(int pageNumber = 1)
        {
            PagedApiResponse<TmdbMovieDto> response = await GetPagedMoviesAsync(
                tmdbSettings.LatestMoviesEndpoint,
                pageNumber);

            return MapTmdbResponse(response);
        }

        public async Task<MoviePagedResponseDto> SearchAsync(MovieSearchDto query)
        {
            string encodedQuery = Uri.EscapeDataString(query.Query.Trim());

            PagedApiResponse<TmdbMovieDto> response = await GetPagedMoviesAsync(
                string.Format(tmdbSettings.SearchMoviesByTitleEndpoint, encodedQuery),
                query.Page);

            if (response.Results.Count == 0)
            {
                response = await GetPagedMoviesAsync(
                   string.Format(tmdbSettings.SearchMoviesByGenreEndpoint, encodedQuery),
                   query.Page);
            }

            return MapTmdbResponse(response);
        }

        private Task<PagedApiResponse<TmdbMovieDto>> GetPagedMoviesAsync(string endpoint, int page)
        {
            return (apiService.GetAsync<PagedApiResponse<TmdbMovieDto>>(
            endpoint,
               new Dictionary<string, string> { { "page", page.ToString() } }))!;
        }

        private MoviePagedResponseDto MapTmdbResponse(PagedApiResponse<TmdbMovieDto> response)
        {
            if (response.Results.Count > 0)
            {
                IReadOnlyList<TmdbGenreDto> genres = genresStore.GetAllGenres();
                return new MoviePagedResponseDto
                {
                    TotalPages = response.TotalPages,
                    CurrentPage = response.Page,
                    Movies = response.Results.Select(m => new MovieDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Overview = m.Overview,
                        ReleaseDate = m.ReleaseDate,
                        BackdropPath = genresStore.GetImageUrl(m.BackdropPath, tmdbSettings.DefaultBackdropSize),
                        VoteAverage = m.VoteAverage,
                        VoteCount = m.VoteCount,
                        OriginalLanguage = m.OriginalLanguage,
                        Genres = m.Genre_Ids.Select(x => genres.First(g => g.Id == x).Name)
                                            .ToList()
                    }).ToList()
                };
            }
            else
            {
                return new MoviePagedResponseDto();
            }
        }
    }
}
