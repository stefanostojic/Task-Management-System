using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.UserProjectService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/userProjects")]
    [Produces("application/json")]
    public class UserProjectsController : ControllerBase
    {
        private readonly IUserProjectService userProjectService;
        private readonly IMapper mapper;

        public UserProjectsController(IUserProjectService userProjectService, IMapper mapper)
        {
            this.userProjectService = userProjectService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetUserProjects")]
        public async Task<ActionResult<PagedResponse<UserProjectResponseDto>>> GetUserProjects([FromQuery] PaginationFilter paginationFilter)
        {
            var userProjects = await userProjectService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<UserProjectResponseDto>()
            {
                CurrentPage = userProjects.CurrentPage,
                PageSize = userProjects.PageSize,
                TotalItems = userProjects.TotalItems,
                TotalPages = userProjects.TotalPages,
                Items = mapper.Map<IEnumerable<UserProjectResponseDto>>(userProjects.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("GetUserProjectById")]
        /// <param name="userId">Used to specify the User.</param>
        /// <param name="projectId">Used to specify the Project.</param>
        public async Task<IActionResult> GetUserProjectById([FromQuery] Guid userId, [FromQuery] Guid projectId)
        {
            var userProject = await userProjectService.GetByIdAsync(userId, projectId);

            if (userProject == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserProjectResponseDto>(userProject));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUserProject([FromBody] UserProjectPostDto userProjectPostDto)
        {
            var userProjectResp = await userProjectService.AddAsync(userProjectPostDto);

            return CreatedAtAction("GetClient", new { userId = userProjectResp.UserID, projectId = userProjectResp.ProjectID }, mapper.Map<UserProjectResponseDto>(userProjectResp));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] Guid userId, [FromQuery] Guid projectId, [FromBody] UserProjectPutDto userProjectPutDto)
        {
            if (userId != userProjectPutDto.UserID || projectId != userProjectPutDto.ProjectID)
            {
                return BadRequest();
            }

            await userProjectService.UpdateAsync(userProjectPutDto);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserProject([FromQuery] Guid userId, [FromQuery] Guid projectId)
        {
            var success = await userProjectService.RemoveByIdAsync(userId, projectId);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
