#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Entities;
using Model.ViewModels;

#endregion

namespace Api.Controllers
{
    [ApiController]
    [Route("posts")]
    [Produces("application/json")]
    public class PostController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;

        public PostController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            var viewModels = await _postService.GetAll();

            if (!viewModels.Any())
                return NoContent();

            return Ok(viewModels);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Post>> Get([FromRoute] Guid id)
        {
            var viewModel = await _postService.Get(id);

            if (viewModel is null)
                return NoContent();

            return Ok(viewModel);
        }

        [HttpGet("{id:guid}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments([FromRoute] Guid id)
        {
            var viewModels = await _commentService.GetByPostId(id);

            if (!viewModels.Any())
                return NoContent();

            return Ok(viewModels);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Post>> Post([Required] [FromBody] CreatePostDto post)
        {
            var viewModel = await _postService.Post(post);

            return Created(string.Empty, viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put([Required] [FromBody] UpdatePostDto post)
        {
            await _postService.Put(post);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _postService.Delete(id);

            return NoContent();
        }
    }
}