using FluentAssertions;
using Moq;
using NextMovie.Application.Entities;
using NextMovie.Application.Interfaces;
using NextMovie.Application.Services;
using NextMovie.Models.DTOs.Domain.Movies;
using System.Linq.Expressions;

namespace NextMovie.Tests
{
    public class MovieCommentServiceTests
    {
        private readonly Mock<IRepository<MovieComment>> movieCommentRepositoryMock;
        private readonly Mock<IRepository<User>> userRepositoryMock;
        private readonly IMovieCommentService movieCommentService;

        public MovieCommentServiceTests()
        {
            movieCommentRepositoryMock = new Mock<IRepository<MovieComment>>();
            userRepositoryMock = new Mock<IRepository<User>>();

            movieCommentService = new MovieCommentService(movieCommentRepositoryMock.Object, userRepositoryMock.Object);
        }

        [Fact]
        public async Task SaveAsync_ShouldSaveMovieCommentForValidData()
        {
            // Arrange
            var comment = new MovieCommentCreationDto
            {
                TmdbMovieId = 101,
                Comment = "Great Movie!"
            };
            User currentUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe"
            };

            var savedComment = new MovieComment
            {
                Id = Guid.NewGuid(),
                TmdbMovieId = comment.TmdbMovieId,
                UserId = currentUser.Id,
                Comment = comment.Comment,
                CreatedAt = DateTime.UtcNow
            };

            movieCommentRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<MovieComment>()))
             .ReturnsAsync(savedComment);

            movieCommentRepositoryMock.Setup(repo => repo.SaveAsync())
              .Returns(Task.CompletedTask);

            userRepositoryMock.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>?>()))
               .ReturnsAsync(currentUser);

            // Act
            var result = await movieCommentService.SaveAsync(comment, currentUser.Id.ToString());

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(savedComment.Id);
            result.UserId.Should().Be(savedComment.UserId);
            result.Comment.Should().Be(savedComment.Comment);
        }


        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfMovies_WhenCommentsExist()
        {
            long tmdbMovieId = 1;
            User user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe"
            };

            var movieComments = new List<MovieComment>
        {
            new MovieComment
            {
                Id = Guid.NewGuid(),
                TmdbMovieId = tmdbMovieId,
                UserId = Guid.NewGuid(),
                User = user,
                Comment = "Great Movie!",
                CreatedAt = DateTime.UtcNow
            },
            new MovieComment
            {
                Id = Guid.NewGuid(),
                User = user,
                TmdbMovieId = tmdbMovieId,
                UserId = Guid.NewGuid(),
                Comment = "Not bad.",
                CreatedAt = DateTime.UtcNow
            }
        };

            movieCommentRepositoryMock.Setup(repo => repo.GetAllAsync(
                It.IsAny<Expression<Func<MovieComment, bool>>>(),
                It.IsAny<int?>(),
                It.IsAny<int?>(),
                It.IsAny<bool>(),
                It.IsAny<Expression<Func<MovieComment, object>>[]>()))
            .ReturnsAsync(movieComments.AsQueryable());

            // Act
            var result = await movieCommentService.GetAllAsync(tmdbMovieId);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Comment.Should().Be("Great Movie!");
            result[1].Comment.Should().Be("Not bad.");
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoCommentsExist()
        {
            // Arrange
            long tmdbMovieId = 200;

            movieCommentRepositoryMock.Setup(repo => repo.GetAllAsync(
                It.IsAny<Expression<Func<MovieComment, bool>>>(),
                It.IsAny<int?>(),
                It.IsAny<int?>(),
                It.IsAny<bool>(),
                It.IsAny<Expression<Func<MovieComment, object>>[]>()))
            .ReturnsAsync(new List<MovieComment>().AsQueryable());

            // Act
            var result = await movieCommentService.GetAllAsync(tmdbMovieId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}

