using System.ComponentModel.DataAnnotations;

namespace NextMovie.Models.DTOs.Domain.Users
{
    public class CreateUserDto
    {
        [StringLength(60, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 60 characters.")]
        public required string FirstName { get; init; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public required string LastName { get; init; }

        [EmailAddress]
        public required string Email { get; init; }

        [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
        [MaxLength(20)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public required string Password { get; init; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public required string ConfirmPassword { get; init; }
    }
}
