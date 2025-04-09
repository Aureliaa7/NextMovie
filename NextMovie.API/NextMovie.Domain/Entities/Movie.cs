namespace NextMovie.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string MovieDbId { get; set; }

        public ICollection<MovieComment> MovieComments { get; set; } = [];
    }
}
