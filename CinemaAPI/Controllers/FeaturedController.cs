using CinemaAPI.Data;
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
        public async Task<ActionResult<List<Movie>>> onGetAsync()
        {
            var sessionsList = (from session in appDbContext.MovieSessions
                                join movie in appDbContext.Movies on session.MovieId equals movie.MovieId
                                join hall in appDbContext.Halls on session.HallId equals hall.HallId
                                where movie.EndOfShow.Year >= 2024 &&
                                    movie.EndOfShow.Month >= 6 &&
                                    movie.EndOfShow.Day >= 4
                                select new
                                {
                                    MovieSessionId = session.MovieSessionId,
                                    MovieTitle = movie.MovieTitle,
                                    HallName = hall.HallName,
                                    HallType = hall.HallType,
                                    Duration = movie.Duration,
                                    Limitations = movie.Limitations,
                                    Rating = movie.Rating,
                                    StartTime = session.StartTime,
                                    TheLowestPrice = session.TheLowestPrice,
                                    MiddlePrice = session.MiddlePrice,
                                    TheHighestPrice = session.TheHighestPrice
                                }        
                ).ToList();

            return Ok(sessionsList);
        }
    }
}
