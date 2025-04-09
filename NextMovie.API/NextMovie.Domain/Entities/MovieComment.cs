namespace NextMovie.Domain.Entities
{
    public class MovieComment
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid MovieId { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; }

        public Movie Movie { get; set; }
    }
}
