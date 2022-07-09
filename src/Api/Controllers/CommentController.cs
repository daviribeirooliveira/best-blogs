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
    [Route("comments")]
    [Produces("application/json")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAll()
        {
            var viewModels = await _commentService.GetAll();

            if (!viewModels.Any())
                return NoContent();

            return Ok(viewModels);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Comment>> Get([FromRoute] Guid id)
        {
            var viewModel = await _commentService.Get(id);

            if (viewModel is null)
                return NoContent();

            return Ok(viewModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CommentViewModel>> Post([Required] [FromBody] CreateCommentDto comment)
        {
            var viewModel = await _commentService.Post(comment);

            return Created(string.Empty, viewModel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdateCommentDto comment)
        {
            await _commentService.Put(comment);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _commentService.Delete(id);

            return NoContent();
        }
    }
}