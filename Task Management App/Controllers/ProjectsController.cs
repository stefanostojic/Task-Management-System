using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.ProjectService;

namespace Task_Management_System.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    [ApiController]
    [Route("api/projects")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResponse<ProjectResponseDto>>> GetProjects([FromQuery] PaginationFilter paginationFilter)
        {
            var projects = await projectService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<ProjectResponseDto>()
            {
                CurrentPage = projects.CurrentPage,
                PageSize = projects.PageSize,
                TotalItems = projects.TotalItems,
                TotalPages = projects.TotalPages,
                Items = mapper.Map<IEnumerable<ProjectResponseDto>>(projects.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var project = await projectService.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProjectResponseDto>(project));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddNewProject([FromBody] ProjectPostDto projectPostDto)
        {
            var projectResp = await projectService.AddAsync(projectPostDto);

            return CreatedAtAction("AddNewProject", new { id = projectResp.ID }, mapper.Map<ProjectResponseDto>(projectResp));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] ProjectPutDto projectPutDto)
        {
            if (id != projectPutDto.ID)
            {
                return BadRequest();
            }

            await projectService.UpdateAsync(projectPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var success = await projectService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
