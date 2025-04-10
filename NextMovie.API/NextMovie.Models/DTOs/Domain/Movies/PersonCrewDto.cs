namespace NextMovie.Models.DTOs.Domain.Movies
{
    public class PersonCrewDto
    {
        public required string Name { get; set; }

        public required string Department { get; set; }

        public string? Character { get; set; }
    }
}
