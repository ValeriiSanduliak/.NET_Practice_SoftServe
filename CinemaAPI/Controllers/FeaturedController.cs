using CinemaAPI.Data;
using CinemaAPI.DTOs;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public FeaturedController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieSession>>> onGetAsync()
        {
            var endDate = new DateOnly(2024, 6, 20);

            var sessionList = await appDbContext
                .MovieSessions
                .Include(ms => ms.Movie)
                .Include(h => h.Hall)
                .Where(ms => ms.Movie.EndOfShow >= endDate)
                .Select(sessionList => new MovieSessionGetNewDTO
                {
                    MovieSessionId = sessionList.MovieSessionId,
                    MovieTitle = sessionList.Movie.MovieTitle,
                    HallName = sessionList.Hall.HallName,
                    HallType = sessionList.Hall.HallType,
                    Duration = sessionList.Movie.Duration,
                    Limitations = sessionList.Movie.Limitations,
                    Rating = sessionList.Movie.Rating,
                    StartTime = sessionList.StartTime,
                    TheLowestPrice = sessionList.TheLowestPrice,
                    MiddlePrice = sessionList.MiddlePrice,
                    TheHighestPrice = sessionList.TheHighestPrice
                })
                .ToListAsync();

            if (sessionList == null || !sessionList.Any())
                return NotFound("Nothing today(");

            return Ok(sessionList);
        }
    }
}
