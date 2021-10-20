using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.UserTaskService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/userTasks")]
    [Produces("application/json")]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTaskService userTaskService;
        private readonly IMapper mapper;

        public UserTasksController(IUserTaskService userTaskService, IMapper mapper)
        {
            this.userTaskService = userTaskService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetUserTasks")]
        public async Task<ActionResult<PagedResponse<UserTaskResponseDto>>> GetUserTasks([FromQuery] PaginationFilter paginationFilter)
        {
            var userTasks = await userTaskService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<UserTaskResponseDto>()
            {
                CurrentPage = userTasks.CurrentPage,
                PageSize = userTasks.PageSize,
                TotalItems = userTasks.TotalItems,
                TotalPages = userTasks.TotalPages,
                Items = mapper.Map<IEnumerable<UserTaskResponseDto>>(userTasks.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("GetUserTaskById")]
        public async Task<IActionResult> GetUserTaskById([FromQuery] Guid userId, [FromQuery] Guid taskId)
        {
            var userTask = await userTaskService.GetByIdAsync(userId, taskId);

            if (userTask == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserTaskResponseDto>(userTask));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUserTask([FromBody] UserTaskPostDto userTaskPostDto)
        {
            var userTaskResp = await userTaskService.AddAsync(userTaskPostDto);

            return CreatedAtAction("GetUserTaskById", new { userId = userTaskResp.UserID, taskId = userTaskResp.TaskID }, mapper.Map<UserTaskResponseDto>(userTaskResp));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] Guid userId, [FromQuery] Guid taskId, [FromBody] UserTaskPutDto userTaskPutDto)
        {
            if (userId != userTaskPutDto.UserID || taskId != userTaskPutDto.TaskID)
            {
                return BadRequest();
            }

            await userTaskService.UpdateAsync(userTaskPutDto);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserTask([FromQuery] Guid userId, [FromQuery] Guid taskId)
        {
            var success = await userTaskService.RemoveByIdAsync(userId, taskId);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
