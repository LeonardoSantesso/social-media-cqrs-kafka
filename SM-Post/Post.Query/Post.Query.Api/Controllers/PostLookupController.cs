﻿using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;
using Post.Query.Api.DTOs;
using Post.Query.Api.Queries;
using Post.Query.Domain.Entities;

namespace Post.Query.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostLookupController : ControllerBase
    {
        private readonly ILogger<PostLookupController> _logger;
        private readonly IQueryDispatcher<PostEntity> _queryDispatcher;

        public PostLookupController(ILogger<PostLookupController> logger, IQueryDispatcher<PostEntity> queryDispatcher)
        {
            _logger = logger;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindAllPostsQuery { });
                return NormalResponse(posts);
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to retrieve all posts!";
                return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
            }
        }

        [HttpGet("byId/{postId}")]
        public async Task<IActionResult> GetByPostIdAsync(Guid postId)
        {
            try
            {
                var post = await _queryDispatcher.SendAsync(new FindPostByIdQuery { Id = postId });

                if (post == null || !post.Any())
                    return NoContent();

                return Ok(new PostLookupResponse
                {
                    Message = $"Successfully returned post!",
                    Posts = post
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to find post by ID!";
                return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
            }
        }

        [HttpGet("byAuthor/{author}")]
        public async Task<IActionResult> GetByPostsAuthorAsync(string author)
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostsByAuthorQuery { Author = author });
                return NormalResponse(posts);
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to find posts by Author!";
                return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
            }
        }

        [HttpGet("withComments")]
        public async Task<IActionResult> GetPostsWithCommentsAsync()
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostsWithCommentsQuery { });
                return NormalResponse(posts);
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to retrieve all posts!";
                return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
            }
        }

        [HttpGet("withLikes/{numberOfLikes}")]
        public async Task<IActionResult> GetByPostsWithLikesrAsync(int numberOfLikes)
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostsWithLikesQuery { NumberOfLikes = numberOfLikes });
                return NormalResponse(posts);
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to find posts with likes!";
                return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
            }
        }

        #region Private methods

        private IActionResult ErrorResponse(Exception ex, string safeErrorMessage)
        {
            _logger.LogError(ex, safeErrorMessage);

            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = safeErrorMessage
            });
        }

        private IActionResult NormalResponse(List<PostEntity> posts)
        {
            if (posts == null || !posts.Any())
                return NoContent();

            var count = posts.Count();

            return Ok(new PostLookupResponse
            {
                Message = $"Successfully returned {count} post{(count > 1 ? "s" : string.Empty)}!",
                Posts = posts
            });
        }

        #endregion
    }
}
