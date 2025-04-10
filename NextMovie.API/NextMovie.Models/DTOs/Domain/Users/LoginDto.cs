using System.ComponentModel.DataAnnotations;

namespace NextMovie.Models.DTOs.Domain.Users
{
    public class LoginDto
    {
        [EmailAddress]
        public required string Email { get; init; }

        public required string Password { get; init; }
    }
}
