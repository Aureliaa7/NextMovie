namespace NextMovie.Models.DTOs.Domain.Movies
{
    public class MoviePagedResponseDto
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public List<MovieDto> Movies { get; set; } = [];
    }
}
