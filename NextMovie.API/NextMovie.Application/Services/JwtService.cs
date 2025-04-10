using Microsoft.IdentityModel.Tokens;
using NextMovie.Application.Entities;
using NextMovie.Application.Exceptions;
using NextMovie.Application.Interfaces;
using NextMovie.Models.DTOs.Domain.Users;
using NextMovie.Models.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NextMovie.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly IRepository<User> userRepository;
        private readonly IPasswordService passwordService;
        private readonly JwtSettings jwtSettings;

        public JwtService(IRepository<User> userRepository,
            IPasswordService passwordService,
            JwtSettings jwtSettings)
        {
            this.userRepository = userRepository;
            this.passwordService = passwordService;
            this.jwtSettings = jwtSettings;
        }

        public async Task<string> GenerateTokenAsync(LoginDto loginDto)
        {
            User user = await userRepository.GetFirstOrDefaultAsync(u => u.Email == loginDto.Email)
                ?? throw new EntityNotFoundException("The user was not found!");

            bool isCorrectPassword = passwordService.IsCorrectPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);

            if (!isCorrectPassword)
            {
                throw new EntityNotFoundException("Invalid credentials!");
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            string jwtKey = jwtSettings.Key;
            var tokenKeyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([ new(ClaimTypes.Email, loginDto.Email),
                    new(Constants.UserFullName, string.Concat(user.FirstName, " ", user.LastName)),
                    new(Constants.UserId, user.Id.ToString())
                ]),
                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpiresInMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKeyBytes),
                    SecurityAlgorithms.HmacSha512Signature),
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
