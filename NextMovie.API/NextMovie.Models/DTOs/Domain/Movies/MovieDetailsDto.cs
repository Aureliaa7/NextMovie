namespace NextMovie.Models.DTOs.Domain.Movies
{
    public class MovieDetailsDto
    {
        public required long Id { get; set; }

        public required List<string> BackdropPaths { get; set; }

        public required List<PersonCrewDto> Crew { get; set; }

        public List<MovieCommentDto> Comments { get; set; } = [];
    }
}
