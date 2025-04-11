using Microsoft.AspNetCore.Mvc;
using NextMovie.Application.Interfaces;
using NextMovie.Models.DTOs.Domain.Users;

namespace NextMovie.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    public class UsersController : NextMovieController
    {
        private readonly IAccountService accountService;

        public UsersController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserDto userDto)
        {
            var createdUser = await accountService.RegisterAsync(userDto);

            return Ok(createdUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            string jwtToken = await accountService.LoginAsync(loginDto);
            if (!string.IsNullOrEmpty(jwtToken))
            {
                return Ok(new { Token = jwtToken });
            }

            return Unauthorized();
        }
    }
}
