﻿namespace NextMovie.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<MovieComment> MovieComments { get; set; } = [];
    }
}
