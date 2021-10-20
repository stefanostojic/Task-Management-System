using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.TaskRoleService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/taskRoles")]
    [Produces("application/json")]
    public class TaskRolesController : ControllerBase
    {
        private readonly ITaskRoleService taskRoleService;
        private readonly IMapper mapper;

        public TaskRolesController(ITaskRoleService taskRoleService, IMapper mapper)
        {
            this.taskRoleService = taskRoleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<TaskRoleResponseDto>>> GetTaskRoles([FromQuery] PaginationFilter paginationFilter)
        {
            var taskRoles = await taskRoleService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<TaskRoleResponseDto>()
            {
                CurrentPage = taskRoles.CurrentPage,
                PageSize = taskRoles.PageSize,
                TotalItems = taskRoles.TotalItems,
                TotalPages = taskRoles.TotalPages,
                Items = mapper.Map<IEnumerable<TaskRoleResponseDto>>(taskRoles.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskRoleById(Guid id)
        {
            var TaskRole = await taskRoleService.GetByIdAsync(id);

            if (TaskRole == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TaskRoleResponseDto>(TaskRole));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTaskRole([FromBody] TaskRolePostDto taskRolePostDto)
        {
            var taskRoleResp = await taskRoleService.AddAsync(taskRolePostDto);

            return CreatedAtAction("GetClient", new { id = taskRoleResp.ID }, mapper.Map<TaskRoleResponseDto>(taskRoleResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] TaskRolePutDto taskRolePutDto)
        {
            if (id != taskRolePutDto.ID)
            {
                return BadRequest();
            }

            await taskRoleService.UpdateAsync(taskRolePutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskRole(Guid id)
        {
            var success = await taskRoleService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
