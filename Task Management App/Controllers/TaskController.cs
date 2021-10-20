using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.TaskService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [Produces("application/json")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IMapper mapper;

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<TaskResponseDto>>> GetTasks([FromQuery] PaginationFilter paginationFilter, [FromQuery] Guid taskGroupId)
        {
            var tasks = await taskService.GetAllAsync(paginationFilter, taskGroupId);

            var pagedResponse = new PagedResponse<TaskResponseDto>()
            {
                CurrentPage = tasks.CurrentPage,
                PageSize = tasks.PageSize,
                TotalItems = tasks.TotalItems,
                TotalPages = tasks.TotalPages,
                Items = mapper.Map<IEnumerable<TaskResponseDto>>(tasks.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute] Guid id)
        {
            var Task = await taskService.GetByIdAsync(id);

            if (Task == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TaskResponseDto>(Task));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTask([FromBody] TaskPostDto taskPostDto)
        {
            var taskResp = await taskService.AddAsync(taskPostDto);

            return CreatedAtAction("GetTaskById", new { id = taskResp.ID }, mapper.Map<TaskResponseDto>(taskResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] TaskPutDto taskPutDto)
        {
            if (id != taskPutDto.ID)
            {
                return BadRequest();
            }

            await taskService.UpdateAsync(taskPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var success = await taskService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
