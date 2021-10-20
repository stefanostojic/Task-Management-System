using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task_Management_System.Auth;
using Task_Management_System.Models;

namespace Task_Management_System.Services
{
    public class AuthService
    {
        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task<TokenReponse> CreateToken(string username, string password)
        {
            User user = await UserManager.FindByNameAsync(username);
            var signInResult = await SignInManager.CheckPasswordSignInAsync(user, password, false);
            if (signInResult.Succeeded)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TMSJwtTokens.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, username)
                };
                var token = new JwtSecurityToken(
                        TMSJwtTokens.Issuer,
                        TMSJwtTokens.Audience,
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: creds
                    );

                var results = new TokenReponse(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);

                return results;
            }

            return null;
        }

        public async Task<bool> RegisterUser(
            string userName,
            string email,
            string password,
            string firstName,
            string lastName)
        {
            var msg = "User already registered";
            try
            {
                User user = await UserManager.FindByNameAsync(userName);
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = userName,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        UserRoleID = Guid.Parse("56860de3-f338-449c-be26-c946d4cb73b0") // NormalUser
                    };

                    IdentityResult result = await UserManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        msg = result.Errors.ToString();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return false;
        }

        public async Task<bool> Logout()
        {
            await SignInManager.SignOutAsync();
            return true;
        }

        public async Task<bool> Login(string userName, string password)
        {
            var result = await SignInManager.PasswordSignInAsync(userName, password, false, false);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
