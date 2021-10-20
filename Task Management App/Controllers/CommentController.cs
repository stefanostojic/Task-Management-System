using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.DTO.Comment;
using Task_Management_System.Services.CommentService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/comments")]
    [Produces("application/json")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<CommentResponseDto>>> GetComments([FromQuery] PaginationFilter paginationFilter)
        {
            var comments = await commentService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<CommentResponseDto>()
            {
                CurrentPage = comments.CurrentPage,
                PageSize = comments.PageSize,
                TotalItems = comments.TotalItems,
                TotalPages = comments.TotalPages,
                Items = mapper.Map<IEnumerable<CommentResponseDto>>(comments.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var comment = await commentService.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CommentResponseDto>(comment));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewComment([FromBody] CommentPostDto commentPostDto)
        {
            var commentResp = await commentService.AddAsync(commentPostDto);

            return CreatedAtAction("GetClient", new { id = commentResp.ID }, mapper.Map<CommentResponseDto>(commentResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] CommentPutDto commentPutDto)
        {
            if (id != commentPutDto.ID)
            {
                return BadRequest();
            }

            await commentService.UpdateAsync(commentPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var success = await commentService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
