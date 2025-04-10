using NextMovie.Models.DTOs.Domain.Users;

namespace NextMovie.Application.Interfaces
{
    public interface IJwtService
    {
        /// <summary>
        /// Generates a JWT token
        /// </summary>
        /// <param name="loginDto">The user's credentials</param>
        /// <returns>A JWT token or an empty string</returns>
        Task<string> GenerateTokenAsync(LoginDto loginDto);
    }
}
