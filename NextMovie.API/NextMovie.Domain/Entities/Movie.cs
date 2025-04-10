﻿namespace NextMovie.Application.Entities
{
    public class Movie : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string MovieDbId { get; set; }

        public ICollection<MovieComment> MovieComments { get; set; } = [];
    }
}
