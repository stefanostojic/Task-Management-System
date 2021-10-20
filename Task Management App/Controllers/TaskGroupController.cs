using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.TaskGroupService;

namespace Task_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskGroupsController : ControllerBase
    {
        private readonly ITaskGroupService taskGroupService;
        private readonly IMapper mapper;

        public TaskGroupsController(ITaskGroupService taskGroupService, IMapper mapper)
        {
            this.taskGroupService = taskGroupService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<TaskGroupResponseDto>>> GetTaskGroups([FromQuery] PaginationFilter paginationFilter)
        {
            var taskGroups = await taskGroupService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<TaskGroupResponseDto>()
            {
                CurrentPage = taskGroups.CurrentPage,
                PageSize = taskGroups.PageSize,
                TotalItems = taskGroups.TotalItems,
                TotalPages = taskGroups.TotalPages,
                Items = mapper.Map<IEnumerable<TaskGroupResponseDto>>(taskGroups.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("projectId/{projectId}")]
        public async Task<ActionResult<IEnumerable<TaskGroupResponseDto>>> GetTaskGroupsByProjectId([FromQuery] PaginationFilter paginationQuery, string projectId)
        {
            var taskGroups = await taskGroupService.GetByProjectIdAsync(paginationQuery, Guid.Parse(projectId));

            return Ok(mapper.Map<List<TaskGroupResponseDto>>(taskGroups));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskGroupById(Guid id)
        {
            var taskGroup = await taskGroupService.GetByIdAsync(id);

            if (taskGroup == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TaskGroupResponseDto>(taskGroup));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTaskGroup([FromBody] TaskGroupPostDto taskGroupPostDto)
        {
            var taskGroupResp = await taskGroupService.AddAsync(taskGroupPostDto);

            //return CreatedAtAction("GetClient", new { id = taskGroupResp.ID }, mapper.Map<TaskGroupResponseDto>(taskGroupResp));
            return Ok(mapper.Map<TaskGroupResponseDto>(taskGroupResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] TaskGroupPutDto taskGroupPutDto)
        {
            if (id != taskGroupPutDto.ID)
            {
                return BadRequest();
            }

            await taskGroupService.UpdateAsync(taskGroupPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskGroup(Guid id)
        {
            var success = await taskGroupService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
