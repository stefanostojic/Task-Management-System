using AutoMapper;
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
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthService AuthService { get; }

        public AuthController(AuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(
            [FromQuery] string userName,
            [FromQuery] string email,
            [FromQuery] string password,
            [FromQuery] string firstName,
            [FromQuery] string lastName)
        {
            var result = await AuthService.RegisterUser(userName, email, password, firstName, lastName);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateToken([FromQuery] string username, [FromQuery] string password)
        {
            var result = await AuthService.CreateToken(username, password);

            if (result != null)
            {
                return Created("", result);
            } else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromQuery] string userName, [FromQuery] string password)
        {
            var result = await AuthService.Login(userName, password);
            if (result)
            {
                return Ok("Login successful");
            }
            else
            {
                return NotFound("User not found.");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await AuthService.Logout();
            return Ok("Logout successful");
        }
    }
}
