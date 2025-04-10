namespace NextMovie.Models.DTOs.MovieDbAPI
{
    public class TmdbMoviePagedResponseDto
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public List<TmdbMovieDto> Movies { get; set; } = [];
    }
}
