using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.DTO.Subtask;
using Task_Management_System.Services.SubtaskService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/subtasks")]
    [Produces("application/json")]
    public class SubtasksController : ControllerBase
    {
        private readonly ISubtaskService subtaskService;
        private readonly IMapper mapper;

        public SubtasksController(ISubtaskService subtaskService, IMapper mapper)
        {
            this.subtaskService = subtaskService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<SubtaskResponseDto>>> GetSubtasks([FromQuery] PaginationFilter paginationFilter)
        {
            var subtasks = await subtaskService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<SubtaskResponseDto>()
            {
                CurrentPage = subtasks.CurrentPage,
                PageSize = subtasks.PageSize,
                TotalItems = subtasks.TotalItems,
                TotalPages = subtasks.TotalPages,
                Items = mapper.Map<IEnumerable<SubtaskResponseDto>>(subtasks.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubtaskById(Guid id)
        {
            var subtask = await subtaskService.GetByIdAsync(id);

            if (subtask == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<SubtaskResponseDto>(subtask));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSubtask([FromBody] SubtaskPostDto subtaskPostDto)
        {
            var subtaskResp = await subtaskService.AddAsync(subtaskPostDto);

            return CreatedAtAction("GetClient", new { id = subtaskResp.ID }, mapper.Map<SubtaskResponseDto>(subtaskResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] SubtaskPutDto subtaskPutDto)
        {
            if (id != subtaskPutDto.ID)
            {
                return BadRequest();
            }

            await subtaskService.UpdateAsync(subtaskPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubtask(Guid id)
        {
            var success = await subtaskService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
