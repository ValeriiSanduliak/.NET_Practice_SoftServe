using CinemaAPI.Data;
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

            var sessionsList = await (from session in appDbContext.MovieSessions
                                      join movie in appDbContext.Movies on session.MovieId equals movie.MovieId
                                      join hall in appDbContext.Halls on session.HallId equals hall.HallId
                                      where movie.EndOfShow >= endDate
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
                ).ToListAsync();

            if (sessionsList is null)
                return NotFound("Nothing today(");

            return Ok(sessionsList);
        }

        [HttpGet("bytime/{hour}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByHourAsync(string hour)
        {
            if (!TimeOnly.TryParse(hour, out TimeOnly selectedTime))
            {
                return BadRequest("Invalid time format. Please provide the time in HH:mm:ss format.");
            }

            TimeOnly endSelectedTime = selectedTime.AddHours(1);

            var sessionsList = await (from session in appDbContext.MovieSessions
                                      join movie in appDbContext.Movies on session.MovieId equals movie.MovieId
                                      join hall in appDbContext.Halls on session.HallId equals hall.HallId
                                      where session.StartTime >= selectedTime && session.StartTime <= endSelectedTime
                                      orderby session.StartTime
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
                ).ToListAsync();

            if (sessionsList == null || sessionsList.Count == 0)
            {
                return NotFound("No movie sessions found for the specified hour.");
            }

            return Ok(sessionsList);
        }

        [HttpGet("bygenre/{genres}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByGenreAsync(string genres)
        {
            var sessionsList = await (from movie_genre in appDbContext.MovieGenres
                                      join movie in appDbContext.Movies on movie_genre.MovieId equals movie.MovieId
                                      join genre in appDbContext.Genres on movie_genre.GenreId equals genre.GenreId
                                      join movie_session in appDbContext.MovieSessions on movie.MovieId equals movie_session.MovieId
                                      join hall in appDbContext.Halls on movie_session.HallId equals hall.HallId
                                      where genre.GenreName == genres
                                      select new
                                      {
                                          MovieSessionId = movie_session.MovieSessionId,
                                          MovieTitle = movie.MovieTitle,
                                          HallName = hall.HallName,
                                          HallType = hall.HallType,
                                          Duration = movie.Duration,
                                          Limitations = movie.Limitations,
                                          Rating = movie.Rating,
                                          StartTime = movie_session.StartTime,
                                          TheLowestPrice = movie_session.TheLowestPrice,
                                          MiddlePrice = movie_session.MiddlePrice,
                                          TheHighestPrice = movie_session.TheHighestPrice
                                      }
                ).ToListAsync();

            if (sessionsList == null || sessionsList.Count == 0)
            {
                return NotFound("No movies of this genre were found in the cinema");
            }

            return Ok(sessionsList);
        }

        [HttpGet("byhall/{halltype}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByHallAsync(string halltype)
        {
            var sessionsList = await (from session in appDbContext.MovieSessions
                                      join movie in appDbContext.Movies on session.MovieId equals movie.MovieId
                                      join hall in appDbContext.Halls on session.HallId equals hall.HallId
                                      where hall.HallType == halltype
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
                ).ToListAsync();

            if (sessionsList == null || sessionsList.Count == 0)
            {
                return NotFound("We do not have such a hall. We only have 2D or 3D");
            }

            return Ok(sessionsList);
        }

        [HttpGet("byrating/{rating}")]
        public async Task<ActionResult<List<MovieSession>>> GetMovieSessionsByRatingAsync(string rating)
        {
            if (!double.TryParse(rating, out double numericRating))
            {
                return BadRequest("Invalid rating value. Rating should be a numeric value.");
            }

            var sessionsList = await (from session in appDbContext.MovieSessions
                                      join movie in appDbContext.Movies on session.MovieId equals movie.MovieId
                                      join hall in appDbContext.Halls on session.HallId equals hall.HallId
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
                ).ToListAsync();

            var filteredSessionsList = sessionsList
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
