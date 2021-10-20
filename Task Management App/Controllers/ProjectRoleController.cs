using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.DTO.ProjectRole;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.ProjectRoleService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/projectRoles")]
    [Produces("application/json")]
    public class ProjectRolesController : ControllerBase
    {
        private readonly IProjectRoleService projectRoleService;
        private readonly IMapper mapper;

        public ProjectRolesController(IProjectRoleService projectRoleService, IMapper mapper)
        {
            this.projectRoleService = projectRoleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<ProjectRoleResponseDto>>> GetProjectRoles([FromQuery] PaginationFilter paginationFilter)
        {
            var projectRoles = await projectRoleService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<ProjectRoleResponseDto>()
            {
                CurrentPage = projectRoles.CurrentPage,
                PageSize = projectRoles.PageSize,
                TotalItems = projectRoles.TotalItems,
                TotalPages = projectRoles.TotalPages,
                Items = mapper.Map<IEnumerable<ProjectRoleResponseDto>>(projectRoles.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectRoleById(Guid id)
        {
            var projectRole = await projectRoleService.GetByIdAsync(id);

            if (projectRole == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProjectRoleResponseDto>(projectRole));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProjectRole([FromBody] ProjectRolePostDto projectRolePostDto)
        {
            var projectRoleResp = await projectRoleService.AddAsync(projectRolePostDto);

            return CreatedAtAction("GetClient", new { id = projectRoleResp.ID }, mapper.Map<ProjectRoleResponseDto>(projectRoleResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] ProjectRolePutDto projectRolePutDto)
        {
            if (id != projectRolePutDto.ID)
            {
                return BadRequest();
            }

            await projectRoleService.UpdateAsync(projectRolePutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectRole(Guid id)
        {
            var success = await projectRoleService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
