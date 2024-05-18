using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;
using CinemaAPI.Data;
using CinemaAPI.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public UserController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsersAsync()
        {
            var users = await appDbContext
                .Users.Select(item => new
                {
                    item.UserId,
                    item.UserName,
                    item.UserEmail,
                    item.UserRole
                })
                .ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            var user = await appDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var returnUser = new
            {
                user.UserId,
                user.UserName,
                user.UserEmail,
                user.UserRole
            };

            return Ok(returnUser);
        }

        [Authorize(Roles = "user, admin")]
        [HttpPatch("ChangeEmail")]
        public async Task<ActionResult<User>> PatchUserAsync(string emailPatch)
        {
            string token = Request.Headers["Authorization"];

            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwt = null;
            try
            {
                jwt = handler.ReadJwtToken(token);
            }
            catch (Exception)
            {
                return Unauthorized("Incorrect or damaged token.");
            }

            string email =
                jwt.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value ?? string.Empty;

            // Find the user by email
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            if (user == null)
            {
                // User with this email does not exist
                return NotFound("User not found");
            }

            if (!new EmailAddressAttribute().IsValid(emailPatch))
            {
                return BadRequest("Invalid email format");
            }

            // Check if the email is already in use
            if (await appDbContext.Users.AnyAsync(u => u.UserEmail == emailPatch))
            {
                return BadRequest("Email is already in use");
            }

            user.UserEmail = emailPatch;
            await appDbContext.SaveChangesAsync();

            var returnUser = new
            {
                user.UserId,
                user.UserName,
                user.UserEmail,
                user.UserRole
            };

            return Ok(returnUser);
        }

        [Authorize(Roles = "user, admin")]
        [HttpPatch("ChangePassword")]
        public async Task<ActionResult<User>> PatchPasswordAsync(
            string previousPassword,
            string passwordPatch
        )
        {
            string token = Request.Headers["Authorization"];

            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwt = null;
            try
            {
                jwt = handler.ReadJwtToken(token);
            }
            catch (Exception)
            {
                return Unauthorized("Incorrect or damaged token.");
            }

            string email =
                jwt.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value ?? string.Empty;

            // Find the user by email
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (Argon2.Verify(user.UserPassword, previousPassword) == false)
            {
                return NotFound("previousPassword");
            }

            if (!Regex.IsMatch(passwordPatch, @"^[a-zA-Z0-9!@#$%^&*()-_+=]+$"))
            {
                return BadRequest(
                    new
                    {
                        message = "Password should contain only English letters, numbers, and special characters"
                    }
                );
            }
            else if (passwordPatch.Length < 8)
            {
                return BadRequest(
                    new { message = "Password should be at least 8 characters long" }
                );
            }
            else if (!passwordPatch.Any(char.IsUpper))
            {
                return BadRequest(
                    new { message = "Password should contain at least one uppercase letter" }
                );
            }
            else if (!passwordPatch.Any(char.IsSymbol) && !passwordPatch.Any(char.IsPunctuation))
            {
                return BadRequest(
                    new { message = "Password should contain at least one special character" }
                );
            }
            else if (passwordPatch.Contains(" "))
            {
                return BadRequest(new { message = "Password cannot contain spaces" });
            }

            user.UserPassword = Argon2.Hash(passwordPatch);
            await appDbContext.SaveChangesAsync();

            var returnUser = new
            {
                user.UserId,
                user.UserName,
                user.UserEmail,
                user.UserRole
            };

            return Ok(returnUser);
        }

        [Authorize(Roles = "user, admin")]
        [HttpPatch("ChangeUserName")]
        public async Task<ActionResult<User>> PatchUserNameAsync(string namePatch)
        {
            string token = Request.Headers["Authorization"];

            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwt = null;
            try
            {
                jwt = handler.ReadJwtToken(token);
            }
            catch (Exception)
            {
                return Unauthorized("Incorrect or damaged token.");
            }

            string email =
                jwt.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value ?? string.Empty;

            // Find the user by email
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            user.UserName = namePatch;
            await appDbContext.SaveChangesAsync();

            var returnUser = new
            {
                user.UserId,
                user.UserName,
                user.UserEmail,
                user.UserRole
            };

            return Ok(returnUser);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("ChangeRole")]
        public async Task<ActionResult<User>> PatchRoleAsync(int userId, string rolePatch)
        {
            // Find the user by email
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Validate the rolePatch value
            if (rolePatch != "user" && rolePatch != "admin")
            {
                return BadRequest("Invalid role. Only 'user' or 'admin' roles are allowed.");
            }

            // Update the user's role
            user.UserRole = rolePatch;
            await appDbContext.SaveChangesAsync();

            var returnUser = new
            {
                user.UserId,
                user.UserName,
                user.UserEmail,
                user.UserRole
            };

            return Ok(returnUser);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            var user = await appDbContext
                .Users.Include(r => r.Reservations)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            appDbContext.Users.Remove(user);
            await appDbContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
