namespace NextMovie.Models.DTOs.Domain.Movies
{
    public class MovieSearchDto
    {
        public string Query { get; set; } = string.Empty;

        public int Page { get; set; } = 1;
    }
}
