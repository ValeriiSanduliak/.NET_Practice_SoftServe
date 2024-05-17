using CinemaAPI.Data;
using CinemaAPI.DTOs;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilltersController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public FilltersController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("bydate/{date}")]
        public async Task<ActionResult<List<MovieSession>>> onGetMovieSessionByDateAsync(DateTime date)
        {
            var endDate = new DateOnly(date.Year, date.Month, date.Day);

            var sessionList = await appDbContext
                .MovieSessions
                .Include(ms => ms.Movie)
                .Include(h => h.Hall)
                .Where(ms => ms.Movie.EndOfShow >= endDate)
                .Select(session => new MovieSessionGetNewDTO
                {
                    MovieSessionId = session.MovieSessionId,
                    MovieTitle = session.Movie.MovieTitle,
                    HallName = session.Hall.HallName,
                    HallType = session.Hall.HallType,
                    Duration = session.Movie.Duration,
                    Limitations = session.Movie.Limitations,
                    Rating = session.Movie.Rating,
                    StartTime = session.StartTime,
                    TheLowestPrice = session.TheLowestPrice,
                    MiddlePrice = session.MiddlePrice,
                    TheHighestPrice = session.TheHighestPrice
                })
                .ToListAsync();

            if (sessionList == null || !sessionList.Any())
                return NotFound("Nothing today(");

            return Ok(sessionList);
        }

        [HttpGet("bytime/{hour}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByHourAsync(string hour)
        {
            if (!TimeOnly.TryParse(hour, out TimeOnly selectedTime))
            {
                return BadRequest("Invalid time format. Please provide the time in HH:mm:ss format.");
            }

            TimeOnly endSelectedTime = selectedTime.AddHours(1);

            var sessionList = await appDbContext
                .MovieSessions
                .Include(ms => ms.Movie)
                .Include(h => h.Hall)
                .Where(session => session.StartTime >= selectedTime && session.StartTime <= endSelectedTime)
                .OrderBy(session => session.StartTime)
                .Select(session => new MovieSessionGetNewDTO
                {
                    MovieSessionId = session.MovieSessionId,
                    MovieTitle = session.Movie.MovieTitle,
                    HallName = session.Hall.HallName,
                    HallType = session.Hall.HallType,
                    Duration = session.Movie.Duration,
                    Limitations = session.Movie.Limitations,
                    Rating = session.Movie.Rating,
                    StartTime = session.StartTime,
                    TheLowestPrice = session.TheLowestPrice,
                    MiddlePrice = session.MiddlePrice,
                    TheHighestPrice = session.TheHighestPrice
                })
                .ToListAsync();

            if (sessionList == null || !sessionList.Any())
                return NotFound("Nothing today(");

            return Ok(sessionList);
        }

        [HttpGet("bygenre/{genres}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByGenreAsync(string genres)
        {
            var sessionsList = await appDbContext.MovieSessions
                .Include(ms => ms.Movie)
                    .ThenInclude(m => m.MovieGenres)
                        .ThenInclude(mg => mg.Genre)
                .Include(ms => ms.Hall)
                .Where(ms => ms.Movie.MovieGenres.Any(mg => mg.Genre.GenreName == genres))
                .Select(ms => new MovieSessionGetNewDTO
                {
                    MovieSessionId = ms.MovieSessionId,
                    MovieTitle = ms.Movie.MovieTitle,
                    HallName = ms.Hall.HallName,
                    HallType = ms.Hall.HallType,
                    Duration = ms.Movie.Duration,
                    Limitations = ms.Movie.Limitations,
                    Rating = ms.Movie.Rating,
                    StartTime = ms.StartTime,
                    TheLowestPrice = ms.TheLowestPrice,
                    MiddlePrice = ms.MiddlePrice,
                    TheHighestPrice = ms.TheHighestPrice
                })
                .ToListAsync();

            if (sessionsList == null || sessionsList.Count == 0)
            {
                return NotFound("No movies of this genre were found in the cinema");
            }

            return Ok(sessionsList);
        }



        [HttpGet("byhall/{halltype}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByHallAsync(string halltype)
        {
            var sessionList = await appDbContext
                .MovieSessions
                .Include(ms => ms.Movie)
                .Include(h => h.Hall)
                .Where(h => h.Hall.HallType == halltype)
                .Select(session => new MovieSessionGetNewDTO
                {
                    MovieSessionId = session.MovieSessionId,
                    MovieTitle = session.Movie.MovieTitle,
                    HallName = session.Hall.HallName,
                    HallType = session.Hall.HallType,
                    Duration = session.Movie.Duration,
                    Limitations = session.Movie.Limitations,
                    Rating = session.Movie.Rating,
                    StartTime = session.StartTime,
                    TheLowestPrice = session.TheLowestPrice,
                    MiddlePrice = session.MiddlePrice,
                    TheHighestPrice = session.TheHighestPrice
                })
                .ToListAsync();

            if (sessionList == null || !sessionList.Any())
                return NotFound("We do not have such a hall. We only have 2D or 3D");

            return Ok(sessionList);
        }

        [HttpGet("byrating/{rating}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByRatingAsync(string rating)
        {
            if (!double.TryParse(rating, out double numericRating))
            {
                return BadRequest("Invalid rating value. Rating should be a numeric value.");
            }

            var sessionList = await appDbContext
                .MovieSessions
                .Include(ms => ms.Movie)
                .Include(h => h.Hall)
                .Select(session => new MovieSessionGetNewDTO
                {
                    MovieSessionId = session.MovieSessionId,
                    MovieTitle = session.Movie.MovieTitle,
                    HallName = session.Hall.HallName,
                    HallType = session.Hall.HallType,
                    Duration = session.Movie.Duration,
                    Limitations = session.Movie.Limitations,
                    Rating = session.Movie.Rating,
                    StartTime = session.StartTime,
                    TheLowestPrice = session.TheLowestPrice,
                    MiddlePrice = session.MiddlePrice,
                    TheHighestPrice = session.TheHighestPrice
                })
                .ToListAsync();


            var filteredSessionsList = sessionList
                .Where(s => {
                    var ratingPart = s.Rating.Split('/')[0];
                    return double.TryParse(ratingPart, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, 
                        out double movieRating) && movieRating >= numericRating;
                })
                .OrderBy(s => {
                    var ratingPart = s.Rating.Split('/')[0];
                    return double.Parse(ratingPart, CultureInfo.InvariantCulture);
                })
                .ToList();

            if (filteredSessionsList == null || filteredSessionsList.Count == 0)
            {
                return NotFound("No sessions found with the specified rating or higher.");
            }

            return Ok(filteredSessionsList);
        }
    }
}
