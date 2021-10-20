using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task_Management_System.Auth;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services;
using Task_Management_System.Services.UserService;

namespace Task_Management_System.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IAuthorizationService authorizationService;

        public UsersController(IUserService service, IMapper mapper, IAuthorizationService authorizationService)
        {
            this.userService = service;
            this.mapper = mapper;
            this.authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<UserResponseDto>>> GetUsers([FromQuery] PaginationFilter paginationFilter)
        {
            var users = await userService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<UserResponseDto>()
            {
                CurrentPage = users.CurrentPage,
                PageSize = users.PageSize,
                TotalItems = users.TotalItems,
                TotalPages = users.TotalPages,
                Items = mapper.Map<IEnumerable<UserResponseDto>>(users.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var User = await userService.GetByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserResponseDto>(User));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] UserPutDto userPutDto)
        {
            if (id != userPutDto.Id)
            {
                return BadRequest();
            }

            var authorizationResult = await authorizationService
                .AuthorizeAsync(User, "EditPolicy");

            await userService.UpdateAsync(userPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var success = await userService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
