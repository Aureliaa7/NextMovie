using Microsoft.AspNetCore.Mvc;
using NextMovie.Application;
using NextMovie.Application.Interfaces;
using NextMovie.Models.DTOs.Domain.Movies;
using System.Security.Claims;

namespace NextMovie.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    public class MovieCommentsController : NextMovieController
    {
        private readonly IMovieCommentService movieCommentService;

        public MovieCommentsController(IMovieCommentService movieCommentService)
        {
            this.movieCommentService = movieCommentService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] MovieCommentCreationDto movieCommentDto)
        {
            string userId = User.FindFirstValue(Constants.UserId) ?? throw new UnauthorizedAccessException("User not found!");
            await movieCommentService.SaveAsync(movieCommentDto, userId);
            return Ok();
        }
    }
}
