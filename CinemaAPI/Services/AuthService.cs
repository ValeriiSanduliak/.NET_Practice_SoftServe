using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CinemaAPI.Data;
using CinemaAPI.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CinemaAPI.Services
{
    public interface IAuthService
    {
        public Task<User> Login(User loginUser);
        public Task<User> Register(User registerUser);
    }

    public class AuthService : IAuthService
    {
        private readonly CinemaDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AuthService(CinemaDbContext dbContext, IConfiguration configuration)
        {
            _appDbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<User> Login(User loginUser)
        {
            // Search user in DB and verify password
            User? user = await _appDbContext.Users.FirstOrDefaultAsync(u =>
                u.UserEmail == loginUser.UserEmail
            );

            Console.WriteLine(
                $"User logged in: {user.UserName} ({user.UserEmail}), Role: {user.UserRole}"
            );

            if (user == null || Argon2.Verify(user.UserPassword, loginUser.UserPassword) == false)
            {
                return null; //returning null intentionally to show that login was unsuccessful
            }

            // Create JWT token handler and get secret key

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserEmail),
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

            // Create token descriptor

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            // Create token and set it to user

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.IsActive = true;

            return user;
        }

        public async Task<User> Register(User registerUser)
        {
            // Add user to DB

            registerUser.UserPassword = Argon2.Hash(registerUser.UserPassword);
            _appDbContext.Users.Add(registerUser);
            await _appDbContext.SaveChangesAsync();

            return registerUser;
        }
    }
}
