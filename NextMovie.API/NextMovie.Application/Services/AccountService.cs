using NextMovie.Application.Entities;
using NextMovie.Application.Exceptions;
using NextMovie.Application.Interfaces;
using NextMovie.Models.DTOs.Domain.Users;

namespace NextMovie.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IJwtService jwtService;
        private readonly IRepository<User> userRepository;
        private readonly IPasswordService passwordService;

        public AccountService(IJwtService jwtService,
            IRepository<User> userRepository,
            IPasswordService passwordService)
        {
            this.jwtService = jwtService;
            this.userRepository = userRepository;
            this.passwordService = passwordService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            string token = string.Empty;
            try
            {
                token = await jwtService.GenerateTokenAsync(loginDto);
            }
            catch (EntityNotFoundException)
            {
                //TODO: log the ex
            }

            return token;
        }

        public async Task<UserDto> RegisterAsync(CreateUserDto userDto)
        {
            bool userExists = await userRepository.ExistsAsync(u => u.Email.Equals(userDto.Email));
            if (userExists)
            {
                throw new DuplicateEmailException("A user with the same email already exists!");
            }

            passwordService.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var newUser = await userRepository.AddAsync(user);
            await userRepository.SaveAsync();

            return new UserDto
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email
            };
        }
    }
}
