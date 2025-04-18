﻿namespace NextMovie.Application.Entities
{
    public class MovieComment : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public long TmdbMovieId { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}
