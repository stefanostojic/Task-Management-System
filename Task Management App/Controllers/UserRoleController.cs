using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.Services.UserRoleService;
using Task_Management_System.Models.DTO.UserRole;
using Task_Management_System.DTO;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/userRoles")]
    [Produces("application/json")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService userRoleService;
        private readonly IMapper mapper;

        public UserRolesController(IUserRoleService userRoleService, IMapper mapper)
        {
            this.userRoleService = userRoleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<UserRoleResponseDto>>> GetUserRoles([FromQuery] PaginationFilter paginationFilter)
        {
            var userRoles = await userRoleService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<UserRoleResponseDto>()
            {
                CurrentPage = userRoles.CurrentPage,
                PageSize = userRoles.PageSize,
                TotalItems = userRoles.TotalItems,
                TotalPages = userRoles.TotalPages,
                Items = mapper.Map<IEnumerable<UserRoleResponseDto>>(userRoles.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRoleById(Guid id)
        {
            var userRole = await userRoleService.GetByIdAsync(id);

            if (userRole == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserRoleResponseDto>(userRole));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUserRole([FromBody] UserRolePostDto userRolePostDto)
        {
            var userRoleResp = await userRoleService.AddAsync(userRolePostDto);

            return CreatedAtAction("GetClient", new { id = userRoleResp.Id }, mapper.Map<UserRoleResponseDto>(userRoleResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] UserRolePutDto userRolePutDto)
        {
            if (id != userRolePutDto.ID)
            {
                return BadRequest();
            }

            await userRoleService.UpdateAsync(userRolePutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(Guid id)
        {
            var success = await userRoleService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
