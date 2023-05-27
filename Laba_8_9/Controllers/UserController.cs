using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Laba_7.Models;
using Laba_7.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Laba_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public UsersController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(Users user)
        {
            // Виконати перевірку введених даних та реалізувати реєстрацію користувача
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = _authService.Register(user);

            if (registeredUser == null)
            {
                return BadRequest("Failed to register user.");
            }

            return Ok(registeredUser);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            // Виконати перевірку введених даних та реалізувати авторизацію користувача
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loggedInUser = _authService.Login(loginModel.Email, loginModel.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
    {
                    new Claim(ClaimTypes.Name, loggedInUser.Id.ToString())
    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            if (loggedInUser == null)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}