using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;
using CinemaAPI.Data;
using CinemaAPI.Models;
using CinemaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly CinemaDbContext _appDbContext;

        public AuthController(CinemaDbContext dbContext, IAuthService authService)
        {
            _appDbContext = dbContext;
            _authService = authService;
        }

        // POST: auth/login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            // Error checks

            if (String.IsNullOrEmpty(user.Email))
            {
                return BadRequest(new { message = "Email needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            if (!new EmailAddressAttribute().IsValid(user.Email))
            {
                return BadRequest("Invalid email format");
            }

            // Try login

            var loggedInUser = await _authService.Login(
                new User("", user.Email, user.Password, "")
            );

            // Return responses

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User login unsuccessful" });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser user)
        {
            // Error checks

            if (String.IsNullOrEmpty(user.Name))
            {
                return BadRequest(new { message = "Name needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.Email))
            {
                return BadRequest(new { message = "Email needs to entered" });
            }
            else if (!new EmailAddressAttribute().IsValid(user.Email))
            {
                return BadRequest("Invalid email format");
            }
            else if (_appDbContext.Users.Any(u => u.UserEmail == user.Email))
            {
                return BadRequest("Email is already in use");
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }
            if (!Regex.IsMatch(user.Password, @"^[a-zA-Z0-9!@#$%^&*()-_+=]+$"))
            {
                return BadRequest(
                    new
                    {
                        message = "Password should contain only English letters, numbers, and special characters"
                    }
                );
            }
            else if (user.Password.Length < 8)
            {
                return BadRequest(
                    new { message = "Password should be at least 8 characters long" }
                );
            }
            else if (!user.Password.Any(char.IsUpper))
            {
                return BadRequest(
                    new { message = "Password should contain at least one uppercase letter" }
                );
            }
            else if (!user.Password.Any(char.IsSymbol) && !user.Password.Any(char.IsPunctuation))
            {
                return BadRequest(
                    new { message = "Password should contain at least one special character" }
                );
            }
            else if (user.Password.Contains(" "))
            {
                return BadRequest(new { message = "Password cannot contain spaces" });
            }

            // Try registration



            var registeredUser = await _authService.Register(
                new User(user.Name, user.Email, user.Password, "user")
            );

            // Return responses

            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }

            return BadRequest(new { message = "User registration unsuccessful" });
        }

        [Authorize(Roles = "user, admin")]
        [HttpGet]
        public IActionResult Test()
        {
            // Get token from header

            string token = Request.Headers["Authorization"];

            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }
            var handler = new JwtSecurityTokenHandler();

            // Returns all claims present in the token

            JwtSecurityToken jwt = handler.ReadJwtToken(token);

            var claims = "List of Claims: \n\n";

            foreach (var claim in jwt.Claims)
            {
                claims += $"{claim.Type}: {claim.Value}\n";

                Console.WriteLine(claims);
            }

            return Ok(claims);
        }
    }
}
